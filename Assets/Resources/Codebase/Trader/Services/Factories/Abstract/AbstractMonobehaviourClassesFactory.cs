using UnityEngine;
using UnityEngine.Pool;

public abstract class AbstractMonobehaviourClassesFactory<Tproduct> : AbstractFactory<Tproduct>, IFactory<Tproduct> where Tproduct : MonoBehaviour
{
    protected AbstractMonobehaviourClassesFactory() : base()
    {
    }
    protected override abstract Tproduct ConstructNew();
    protected override void OnGetFromPool(Tproduct product) => 
        product.gameObject.SetActive(true);
    protected override void OnReturnedToPool(Tproduct product) =>
        product.gameObject.SetActive(false);
    protected override void OnDestroyPoolObject(Tproduct product) =>
        GameObject.Destroy(product.gameObject);
}