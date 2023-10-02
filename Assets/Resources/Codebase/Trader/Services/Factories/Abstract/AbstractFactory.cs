using System;
using UnityEngine.Pool;
public abstract class AbstractFactory<TProduct> : IFactory<TProduct> where TProduct : class
{
    protected ObjectPool<TProduct> _pool;

    public AbstractFactory() => 
        InitializePool();

    public TProduct GetProduct() => 
        _pool.Get();

    protected abstract void OnDestroyPoolObject(TProduct product);
    protected abstract void OnReturnedToPool(TProduct product);
    protected abstract void OnGetFromPool(TProduct product);
    protected abstract TProduct ConstructNew();
    private void InitializePool()
    {
        _pool = new(
                    createFunc: ConstructNew,
                    actionOnGet: OnGetFromPool,
                    actionOnRelease: OnReturnedToPool,
                    actionOnDestroy: OnDestroyPoolObject);
    }
}