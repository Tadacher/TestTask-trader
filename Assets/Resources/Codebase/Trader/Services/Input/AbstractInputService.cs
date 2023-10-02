using System;
using System.Collections;
using UnityEngine;

namespace Services
{
    public abstract class AbstractInputService : IOnPointerUpEventProvider
    {
        public event Action OnPointerUp;
        protected MonoBehaviour _coroutineRunner;
        protected Coroutine _inputRecievingCoroutine;
        protected Camera _mainCamera;
        public AbstractInputService(MonoBehaviour coroutineRunner)
        {
            _mainCamera = Camera.main;
            _coroutineRunner = coroutineRunner;
        }

        public abstract Vector3 GetpointerPositionOnScreen();
        public abstract Vector3 GetpointerPositionWorld();

        protected abstract IEnumerator InputRecievingCoroutine();
        protected void InvokeOnPointerUp() => 
            OnPointerUp.Invoke();
    }
}
