using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlotGame.Data;
using SlotGame.Enums;

namespace SlotGame.Controllers
{
    public class SlotMachineController : MonoBehaviour
    {
        [Header("Reels & Data")]
        [SerializeField] private List<ReelController> reels;
        [SerializeField] private List<SymbolData> availableSymbols;

        [Header("System References")]
        [SerializeField] private BetManager betManager;
        [SerializeField] private PaylineEvaluator paylineEvaluator;

        private SlotState currentState = SlotState.Idle;

        public SlotState CurrentState => currentState;

        private void Start()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            if (reels != null)
            {
                foreach (var reel in reels)
                {
                    if (reel != null) reel.InitializeReel(availableSymbols);
                }
            }
        }

        public void Spin()
        {
            if (currentState != SlotState.Idle) return;
            if (betManager == null || !betManager.CanBet()) return;

            betManager.DeductBet();
            StartCoroutine(SpinRoutine());
        }

        private IEnumerator SpinRoutine()
        {
            currentState = SlotState.Spinning;

            float baseDuration = 1.5f;
            float reelStagger = 0.5f;

            for (int i = 0; i < reels.Count; i++)
            {
                if (reels[i] != null)
                {
                    reels[i].SpinReel(baseDuration + (i * reelStagger), null);
                }
            }

            yield return new WaitForSeconds(baseDuration + ((reels.Count - 1) * reelStagger) + 0.3f);

            currentState = SlotState.Evaluating;
            EvaluateSpinResults();
        }

        private void EvaluateSpinResults()
        {
            SymbolData[,] currentGrid = GetCurrentGridMatrix();

            if (paylineEvaluator != null && betManager != null)
            {
                List<PaylineResult> winResults = paylineEvaluator.EvaluateGrid(currentGrid, betManager.CurrentBet);
                int totalWin = 0;

                foreach (var res in winResults) totalWin += res.WinAmount;

                if (totalWin > 0)
                {
                    currentState = SlotState.WinCelebration;
                    betManager.AddWin(totalWin);
                }
            }

            currentState = SlotState.Idle;
        }

        private SymbolData[,] GetCurrentGridMatrix()
        {
            return new SymbolData[3, 3];
        }
    }
}
