public class ItemFactory : AbstractFactory<Item>
{
    protected override Item ConstructNew() => 
        new();

    protected override void OnDestroyPoolObject(Item product)
    {
        //
    }

    protected override void OnReturnedToPool(Item product)
    {
       //
    }

    protected override void OnGetFromPool(Item product)
    {
        //
    }
}