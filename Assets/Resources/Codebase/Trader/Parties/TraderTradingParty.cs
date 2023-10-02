using Enums;

public class TraderTradingParty : AbstractTradingParty, ITradingParty
{

    private const float _sellMod = 1.2f;

    public TraderTradingParty() : base(Side.Right, Side.Left) { }

    public override void BuyItem(Item item)
        => item.SetOwner(_side);
    public override int GetSellingPrice(Item item) 
        => (int)(item.Price * _sellMod);

    /// <summary>
    /// Считаем, что денег у торгаша бесконечно много
    /// </summary>
    public override bool CanAffordItem(int itemPrice) => true;
}