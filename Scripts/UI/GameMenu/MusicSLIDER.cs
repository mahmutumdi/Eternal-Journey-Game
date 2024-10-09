using Events;
using UI.MainMenu;
using UnityEngine;
using Utilities;

namespace UI.GameMenu
{
    public class MusicSLIDER : UISLIDER
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            _slider.value = GameMenuManager.Instance.MusicVal;
        }
        protected override void OnValueChanged(float val)
        {
            GameMenuEvents.MusicSliderUAction?.Invoke(val);
        }
    }
}