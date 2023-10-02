using TMPro;

namespace Services
{
    public class UiService : IMoneyDisplayer
    {
        private TextMeshProUGUI _moneyText;

        public UiService(TextMeshProUGUI moneyText) => 
            _moneyText = moneyText;

        public void DisplayMoney(int count) => 
            _moneyText.text = count.ToString();
    }
}
