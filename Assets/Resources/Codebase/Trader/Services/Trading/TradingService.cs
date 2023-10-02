using Enums;
using UnityEngine;
namespace Services
{
    public class TradingService : ISelector<Item>, ISelector<ItemComponent>
    {
        private Item _activeItem;
        private ItemComponent _activeItemComponent;

        private RectUtility _rectUtility;
        private ItemsPositionService _itemsPositionService;
      
        private ITradingParty _leftParty;
        private ITradingParty _rightParty;
        private IOnPointerUpEventProvider _onPointerUpEventProvider;

        public TradingService(RectUtility rectUtility, UiContainer uiContainer, IOnPointerUpEventProvider onPointerUpEventProvider, IMoneyDisplayer _uiService)
        {

            _itemsPositionService = new(uiContainer.LeftRectTransform, uiContainer.RightRectTransform);
            _leftParty = new PlayerTradingParty(_uiService);
            _rightParty = new TraderTradingParty();

            _rectUtility = rectUtility;
            _onPointerUpEventProvider = onPointerUpEventProvider;
            _onPointerUpEventProvider.OnPointerUp += DeselectItem;
        }

        public void Select(Item item) =>
            _activeItem = item;
        public void Select(ItemComponent item) =>
            _activeItemComponent = item;

        public void SendGeneratedItemToLeftSide(ItemComponent item) => 
            _itemsPositionService.SendNewItemToLeftInventory(item);
        public void SendGeneratedItemToRightSide(ItemComponent item) => 
            _itemsPositionService.SendNewItemToRightInventory(item);

        public void GiftItemToLeft(ItemComponent item)
        {
            _itemsPositionService.SendItemToLeftInventory(item);
            item.Item.SetOwner(Side.Left);
        }
        public void GiftItemToRight(ItemComponent item)
        {
            _itemsPositionService.SendItemToRightInventory(item);
            item.Item.SetOwner(Side.Right);
        }
    
        private void DeselectItem()
        {
            
            if (_activeItem == null)
                return;

            Side pointedSide = _rectUtility.GetSideFromPointerPosition();

            if (pointedSide == _activeItem.Owner || pointedSide == Side.None)
                ReturnActiveItemToInventory();

            else
                SellActiveItem();

            _activeItemComponent = null;
            _activeItem = null;
        }

        private void ReturnActiveItemToInventory() =>
           _itemsPositionService.SendItemToSameInventory(_activeItemComponent);

        private void SellActiveItem()
        {
            Debug.Log(_activeItem.Owner.ToString());
          
            if (_activeItem.Owner is Side.Left && CanRightPartyAffordActiveItem())
                LeftPartySellActiveItem();

            else if (_activeItem.Owner is Side.Right && CanLeftPartyAffordActiveItem())
                RightPartySellActiveItem();

            else
                ReturnActiveItemToInventory();  
        }

        private void RightPartySellActiveItem()
        {
            _itemsPositionService.SendItemGameobjectToOppositeInventory(_activeItemComponent);
            _rightParty.SellItem(_activeItem);
            int price = _rightParty.GetSellingPrice(_activeItem);
            _leftParty.SpendMoney(price);
            _activeItem.SetOwner(Side.Left);
        }

        private void LeftPartySellActiveItem()
        {
            _itemsPositionService.SendItemGameobjectToOppositeInventory(_activeItemComponent);
            _leftParty.SellItem(_activeItem);
            int price = _leftParty.GetSellingPrice(_activeItem);
            _rightParty.SpendMoney(price);
            _activeItem.SetOwner(Side.Right);
        }

        private bool CanLeftPartyAffordActiveItem() => 
            _leftParty.CanAffordItem(_rightParty.GetSellingPrice(_activeItem));

        private bool CanRightPartyAffordActiveItem() =>
            _rightParty.CanAffordItem(_leftParty.GetSellingPrice(_activeItem));

        ~TradingService()
        {
            _onPointerUpEventProvider.OnPointerUp -= DeselectItem;
        }
    }
}
