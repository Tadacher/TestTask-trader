using Services;
using UnityEngine;

public class ItemGameobjectFactory : AbstractMonobehaviourClassesFactory<ItemComponent>
{
    private IFactory<Item> _itemfactory;
    private ItemComponent _prefab;

    //product dependencies
    private ISelector<Item> _itemSelector;
    private ISelector<ItemComponent> _itemComponentSelector;
    private AbstractInputService _inputService;
    private Transform _generalCanvasTransform;

    public ItemGameobjectFactory(ISelector<Item> itemSelector, ISelector<ItemComponent> itemComponentSelector, AbstractInputService abstractInputService, Transform generalCanvas,ItemComponent prefab) : base()
    {
        _itemSelector = itemSelector;
        _itemComponentSelector = itemComponentSelector;
        _itemfactory = new ItemFactory();
        _inputService = abstractInputService;
        _prefab = prefab;
        _generalCanvasTransform = generalCanvas;
    }

    protected override ItemComponent ConstructNew()
    {
        ItemComponent product = UnityEngine.Object.Instantiate(_prefab);
        product.Init(_itemSelector, _itemComponentSelector, _itemfactory.GetProduct(), _inputService, _generalCanvasTransform);
        return product;
    }
}