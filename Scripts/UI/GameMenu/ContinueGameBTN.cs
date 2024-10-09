using Events;
using Utilities;

namespace UI.GameMenu
{
    public class ContinueGameBTN : UIBTN
    {
        protected override void OnClick()
        {
            GameMenuEvents.ContinueGameBtnUAction?.Invoke();
        }
    }
}