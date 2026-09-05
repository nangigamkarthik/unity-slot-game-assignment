using UnityEngine;

namespace SlotGame.Controllers
{
    public class BetManager : MonoBehaviour
    {
        [Header("Balance & Bet Settings")]
        [SerializeField] private int initialBalance = 1000;
        [SerializeField] private int betIncrement = 5;
        [SerializeField] private int minBet = 5;
        [SerializeField] private int maxBet = 100;

        public int Balance { get; private set; }
        public int CurrentBet { get; private set; }

        private void Awake()
        {
            Balance = initialBalance;
            CurrentBet = minBet;
        }

        public bool CanBet() => Balance >= CurrentBet;

        public void DeductBet()
        {
            if (CanBet()) Balance -= CurrentBet;
        }

        public void AddWin(int winAmount)
        {
            Balance += winAmount;
        }

        public void IncreaseBet()
        {
            if (CurrentBet + betIncrement <= maxBet && CurrentBet + betIncrement <= Balance)
            {
                CurrentBet += betIncrement;
            }
        }

        public void DecreaseBet()
        {
            if (CurrentBet - betIncrement >= minBet)
            {
                CurrentBet -= betIncrement;
            }
        }

        public void SetMaxBet()
        {
            CurrentBet = Mathf.Min(maxBet, Balance);
        }
    }
}
