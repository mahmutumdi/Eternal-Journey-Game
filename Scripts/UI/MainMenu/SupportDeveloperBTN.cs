using Events;
using Utilities;

namespace UI.MainMenu
{
    public class SupportDeveloperBTN: UIBTN
    {
        protected override void OnClick()
        {
            MainMenuEvents.SupportDeveloperBtnUAction?.Invoke();
        }
    }
}