using Enums;
using UnityEngine;

namespace Services
{
    public class RectUtility
    {
        private AbstractInputService _inputService;
        private RectTransform _leftSide;
        private RectTransform _rightSide;
        private RectTransformUtility _transformUtility;
        public RectUtility(AbstractInputService inputService, RectTransform leftSide, RectTransform rightSide)
        {
            _inputService = inputService;
            _leftSide = leftSide;
            _rightSide = rightSide;    
        }

        public Side GetSideFromPointerPosition()
        {
            Vector3 pointerPosition = _inputService.GetpointerPositionOnScreen();

            if (RectTransformUtility.RectangleContainsScreenPoint(_leftSide, pointerPosition))
                return Side.Left;

            else if (RectTransformUtility.RectangleContainsScreenPoint(_rightSide, pointerPosition))
                return Side.Right;

            else
                return Side.None;
        }
    }
}