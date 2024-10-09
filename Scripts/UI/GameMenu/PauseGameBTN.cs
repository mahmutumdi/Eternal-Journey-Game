using Events;
using Utilities;

namespace UI.GameMenu
{
    public class PauseGameBTN : UIBTN
    {
        protected override void OnClick()
        {
            GameMenuEvents.PauseGameBtnUAction?.Invoke();
        }
    }
}