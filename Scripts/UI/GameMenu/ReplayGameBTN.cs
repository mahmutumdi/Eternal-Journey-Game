using Events;
using Utilities;

namespace UI.GameMenu
{
    public class ReplayGameBTN : UIBTN
    {
        protected override void OnClick()
        {
            GameMenuEvents.ReplayGameBtnUAction?.Invoke();
        }
    }
}