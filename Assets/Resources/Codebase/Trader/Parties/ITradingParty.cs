internal interface ITradingParty
{
    public void BuyItem(Item item);
    public void SellItem(Item item);
    public int GetSellingPrice(Item item);
    public void SpendMoney(int amount);
    bool CanAffordItem(int itemPrice);
}