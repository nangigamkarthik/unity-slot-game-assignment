using UnityEngine;

namespace SlotGame.Data
{
    public enum SymbolType
    {
        Cherry,
        Lemon,
        Orange,
        Grape,
        Bell,
        Seven,
        Diamond,
        Wild
    }

    [CreateAssetMenu(fileName = "NewSymbolData", menuName = "SlotGame/Symbol Data")]
    public class SymbolData : ScriptableObject
    {
        [Header("Symbol Identity")]
        public SymbolType type;
        public string symbolName;
        public Sprite symbolSprite;

        [Header("Payout & RNG Metrics")]
        [Tooltip("Payout multiplier when 3 matching symbols land on a payline.")]
        public int payoutMultiplier = 10;

        [Tooltip("RNG weight for symbol distribution (higher = more frequent).")]
        [Range(1, 100)]
        public int rngWeight = 10;

        public bool isWild = false;
    }
}
