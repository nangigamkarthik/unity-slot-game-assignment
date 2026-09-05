using UnityEngine;
using UnityEngine.UI;
using SlotGame.Enums;

namespace SlotGame.Controllers
{
    public class UIManager : MonoBehaviour
    {
        [Header("UI Text Display References")]
        [SerializeField] private Text balanceText;
        [SerializeField] private Text betText;
        [SerializeField] private Text winText;

        [Header("Controls")]
        [SerializeField] private Button spinButton;
        [SerializeField] private Button betPlusButton;
        [SerializeField] private Button betMinusButton;

        [Header("System References")]
        [SerializeField] private BetManager betManager;
        [SerializeField] private SlotMachineController slotMachineController;

        private void Update()
        {
            UpdateUIDisplay();
        }

        public void UpdateUIDisplay()
        {
            if (betManager != null)
            {
                if (balanceText != null) balanceText.text = betManager.Balance.ToString();
                if (betText != null) betText.text = betManager.CurrentBet.ToString();
            }

            if (spinButton != null && slotMachineController != null)
            {
                spinButton.interactable = slotMachineController.CurrentState == SlotState.Idle &&
                                          betManager != null && betManager.CanBet();
            }
        }

        public void OnSpinButtonClicked()
        {
            if (slotMachineController != null) slotMachineController.Spin();
        }

        public void OnBetIncreaseClicked()
        {
            if (betManager != null) betManager.IncreaseBet();
        }

        public void OnBetDecreaseClicked()
        {
            if (betManager != null) betManager.DecreaseBet();
        }
    }
}
