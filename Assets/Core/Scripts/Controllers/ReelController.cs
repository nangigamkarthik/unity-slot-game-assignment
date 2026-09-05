using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlotGame.Data;

namespace SlotGame.Controllers
{
    public class ReelController : MonoBehaviour
    {
        [Header("Reel Configuration")]
        [SerializeField] private List<Transform> symbolSlots;
        [SerializeField] private float spinSpeed = 1800f;
        [SerializeField] private float reelHeight = 150f;

        private bool isSpinning = false;
        private List<SymbolData> availableSymbols;

        public bool IsSpinning => isSpinning;

        public void InitializeReel(List<SymbolData> symbols)
        {
            availableSymbols = symbols;
            RandomizeSymbols();
        }

        public void SpinReel(float duration, System.Action onComplete)
        {
            StartCoroutine(SpinRoutine(duration, onComplete));
        }

        private IEnumerator SpinRoutine(float duration, System.Action onComplete)
        {
            isSpinning = true;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float step = spinSpeed * Time.deltaTime;

                foreach (Transform slot in symbolSlots)
                {
                    if (slot != null)
                    {
                        slot.localPosition -= new Vector3(0, step, 0);

                        if (slot.localPosition.y <= -reelHeight)
                        {
                            slot.localPosition += new Vector3(0, reelHeight * symbolSlots.Count, 0);
                            AssignRandomSymbol(slot);
                        }
                    }
                }
                yield return null;
            }

            yield return BounceToSnapPosition();

            isSpinning = false;
            onComplete?.Invoke();
        }

        private IEnumerator BounceToSnapPosition()
        {
            float bounceDuration = 0.25f;
            float elapsed = 0f;

            while (elapsed < bounceDuration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / bounceDuration;
                float bounceOffset = Mathf.Sin(t * Mathf.PI) * 10f;

                foreach (Transform slot in symbolSlots)
                {
                    if (slot != null)
                    {
                        slot.localPosition += new Vector3(0, bounceOffset * Time.deltaTime, 0);
                    }
                }
                yield return null;
            }
        }

        private void AssignRandomSymbol(Transform slot)
        {
            if (availableSymbols == null || availableSymbols.Count == 0) return;
            SymbolData sym = availableSymbols[Random.Range(0, availableSymbols.Count)];
            SpriteRenderer sr = slot.GetComponent<SpriteRenderer>();
            if (sr != null) sr.sprite = sym.symbolSprite;
        }

        private void RandomizeSymbols()
        {
            foreach (Transform slot in symbolSlots)
            {
                if (slot != null) AssignRandomSymbol(slot);
            }
        }
    }
}
