using Events;
using Utilities;

namespace UI.GameMenu
{
    public class GoMainMenuBTN : UIBTN
    {
        protected override void OnClick()
        {
            GameMenuEvents.GoMainMenuBtnUAction?.Invoke();
        }
    }
}