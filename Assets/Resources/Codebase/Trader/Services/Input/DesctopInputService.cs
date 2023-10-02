using System.Collections;
using UnityEngine;

namespace Services
{
    public class DesctopInputService : AbstractInputService
    {
        public DesctopInputService(MonoBehaviour coroutineRunner) : base(coroutineRunner) => 
           _inputRecievingCoroutine = _coroutineRunner.StartCoroutine(InputRecievingCoroutine());

        public override Vector3 GetpointerPositionWorld() =>
            _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        public override Vector3 GetpointerPositionOnScreen() => 
            Input.mousePosition;

        protected override IEnumerator InputRecievingCoroutine()
        {
            while (true)
            {
                if(Input.GetMouseButtonUp(0))
                    InvokeOnPointerUp();

                yield return null;
            }
        }

        ~DesctopInputService()
        {
            _coroutineRunner?.StopCoroutine(_inputRecievingCoroutine);
        }
    }
}
