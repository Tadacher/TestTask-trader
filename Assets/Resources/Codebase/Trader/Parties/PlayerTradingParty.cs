using Enums;
using Services;

public class PlayerTradingParty : AbstractTradingParty
{
    private IMoneyDisplayer _moneyDisplayer;
    public PlayerTradingParty(IMoneyDisplayer moneyDisplayer) : base(Side.Left, Side.Right)
    {
        _money = 120;
        _moneyDisplayer = moneyDisplayer;

        DrawMoneyCount();
    }


    public override void BuyItem(Item item)
    {
        throw new System.NotImplementedException();
    }

    public override int GetSellingPrice(Item item) => 
        item.Price;

    protected override void RecieveMoney(int amount)
    {
        base.RecieveMoney(amount);
        DrawMoneyCount();
    }
    public override void SpendMoney(int amount)
    {
        base.SpendMoney(amount);
        DrawMoneyCount();
    }
    private void DrawMoneyCount() => 
        _moneyDisplayer.DisplayMoney(_money);

}