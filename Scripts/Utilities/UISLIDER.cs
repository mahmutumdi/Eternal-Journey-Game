using UnityEngine;
using UnityEngine.UI;

namespace Utilities
{
    public abstract class UISLIDER : EventListenerMono
    {
        [SerializeField] protected Slider _slider;
        protected override void RegisterEvents()
        {
            _slider.onValueChanged.AddListener(OnValueChanged);
        }
        
        protected abstract void OnValueChanged(float val);

        protected override void UnRegisterEvents()
        {
            _slider.onValueChanged.AddListener(OnValueChanged);
        }
    }
}