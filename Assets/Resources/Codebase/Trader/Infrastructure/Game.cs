using Services;
using UnityEngine;

public class Game
{
    private ITradingParty _player;
    private ITradingParty _trader;
    private IFactory<ItemComponent> _itemGameobjectFactory;

    private UiService _uiService;
    private TradingService _tradingService;
    private AbstractInputService _inputService;

    public Game(UiContainer uiContainer, MonoBehaviour coroutineRunner, ItemComponent itemPrefab)
    {
        _uiService = new(uiContainer.MoneyText);
        _player = new PlayerTradingParty(_uiService);
        _trader = new TraderTradingParty();
        _inputService = new DesctopInputService(coroutineRunner);

        RectUtility rectUtility = new RectUtility(_inputService, uiContainer.LeftSideRect, uiContainer.RightSideRect);

        _tradingService = new(rectUtility, uiContainer, _inputService, _uiService);
        _itemGameobjectFactory = new ItemGameobjectFactory(_tradingService, _tradingService, _inputService, uiContainer.GeneralTradeCanvasTransform, itemPrefab);

        SpawnInitialItems();
    }

    private void SpawnInitialItems()
    {
        for(int i = 0; i < 5;  i++)
         _tradingService.SendGeneratedItemToRightSide(_itemGameobjectFactory.GetProduct());
    }
}
