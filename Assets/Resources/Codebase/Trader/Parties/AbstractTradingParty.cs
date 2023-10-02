using Enums;

public abstract class AbstractTradingParty : ITradingParty
{
    public int Money => _money;
    
    protected int _money;
    protected readonly Side _side;
    protected readonly Side _opposeSide;

    protected AbstractTradingParty(Side side, Side opposeSide)
    {
        _side = side;
        _opposeSide = opposeSide;
    }

    public abstract void BuyItem(Item item);
    public abstract int GetSellingPrice(Item item);

    public virtual void SellItem(Item item) => 
        RecieveMoney(GetSellingPrice(item));
    public virtual bool CanAffordItem(int itemPrice) => 
        itemPrice <= _money;
    public virtual void SpendMoney(int amount) => 
        _money -= amount;
    
    protected virtual void RecieveMoney(int amount) =>
       _money += amount;
}
