using UnityEngine;

namespace EdgePathFinder
{
    public class EntryPoint : MonoBehaviour
    {
        private EdgePathFinder _edgePathFinder;
        private void Awake()
        {
            _edgePathFinder = new();
        }
    }
}