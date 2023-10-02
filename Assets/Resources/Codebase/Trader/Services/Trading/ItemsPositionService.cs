using Enums;
using UnityEngine;

namespace Services
{
    public class ItemsPositionService
    {
        private Transform _leftSide;
        private Transform _rightSide;

        public ItemsPositionService(Transform leftSide, Transform rightSide)
        {
            _leftSide = leftSide;
            _rightSide = rightSide;
        }

        public void SendItemGameobjectToOppositeInventory(ItemComponent item)
        {
            if(item.Item.Owner == Side.Left)
                SendItemToRightInventory(item);

            else if(item.Item.Owner == Side.Right)
                SendItemToLeftInventory(item);
        }
        public void SendItemToSameInventory(ItemComponent item)
        {
            
            if (item.Item.Owner == Side.Left)
                SendItemToLeftInventory(item);

            else if (item.Item.Owner == Side.Right)
                SendItemToRightInventory(item);
        }
        public void SendItemToLeftInventory(ItemComponent item)
        {
            item.StopFollowingCoroutine();
            item.transform.SetParent(_leftSide);
        }

        public void SendItemToRightInventory(ItemComponent item)
        {
            item.StopFollowingCoroutine();
            item.transform.SetParent(_rightSide);
        }
        public void SendNewItemToLeftInventory(ItemComponent item) =>
            item.transform.SetParent(_leftSide);

        public void SendNewItemToRightInventory(ItemComponent item) => 
            item.transform.SetParent(_rightSide);
    }
}