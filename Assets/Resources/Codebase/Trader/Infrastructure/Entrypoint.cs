using UnityEngine;

public class Entrypoint : MonoBehaviour
{

    [SerializeField] private UiContainer _uiContainer;
    [SerializeField] private MonoBehaviour _coroutineRunner;
    [SerializeField] private ItemComponent _itemPrefab;

    private Game _game;

    private void Awake() => 
        _game = new(_uiContainer, _coroutineRunner, _itemPrefab);
}
