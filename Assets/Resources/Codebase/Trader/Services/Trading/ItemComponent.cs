using Services;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemComponent : MonoBehaviour, IPointerDownHandler
{
    public Item Item => _item;

    private ISelector<Item> _itemSelector;
    private ISelector<ItemComponent> _itemcomponentSelector;
    private Item _item;
    private Coroutine _followingCoroutine;
    private AbstractInputService _input;
    private Transform _generalCanvas;
    private RectTransform _transform;

    public void Init(ISelector<Item> itemSelector, ISelector<ItemComponent> itemcomponentSelector, Item item, AbstractInputService inputService, Transform generalCanvas)
    {
        _itemSelector = itemSelector;
        _itemcomponentSelector = itemcomponentSelector;
        _item = item;
        _input = inputService;
        _generalCanvas = generalCanvas;
        _transform = GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _itemSelector.Select(_item);
        _itemcomponentSelector.Select(this);
        StartFollowingPointer();
    }
    public void StopFollowingCoroutine() => 
        StopCoroutine(_followingCoroutine);
    private void StartFollowingPointer() => 
        _followingCoroutine = StartCoroutine(FollowingCoroutine());

    private IEnumerator FollowingCoroutine()
    {
        transform.SetParent(_generalCanvas);
        while (true)
        {
            _transform.position = _input.GetpointerPositionOnScreen();
            yield return null;
        }
    } 
}
