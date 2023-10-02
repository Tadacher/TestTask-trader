using TMPro;
using UnityEngine;

public class UiContainer : MonoBehaviour
{
    public RectTransform LeftSideRect => _leftSideRect;
    public RectTransform RightSideRect => _rightSideRect;
    public Transform GeneralTradeCanvasTransform => _generalTradeCanvasTransform;
    public Transform LeftRectTransform => _leftSideRect.transform;
    public Transform RightRectTransform => _rightSideRect.transform;
    public TextMeshProUGUI MoneyText => _moneyText;


    [SerializeField] private RectTransform _leftSideRect;
    [SerializeField] private RectTransform _rightSideRect;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private Transform _generalTradeCanvasTransform;
   
}