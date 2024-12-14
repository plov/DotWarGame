using System;
using Code.Observing.UnityEvents;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Core
{
    public abstract class BaseBtn : MonoBehaviour
    {
            [SerializeField]
            private Button _button;

            private IDisposable _subscriber;

            protected Button Button => _button;

            private void Awake() =>
                _subscriber = _button.OnClick(OnClick);

            private void OnDestroy()
            {
                _subscriber.Dispose();
                CustomOnDestroy();
            }

            protected virtual void CustomOnDestroy() { }

            protected abstract void OnClick();
    }
}