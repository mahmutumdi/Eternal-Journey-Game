using Events;
using Utilities;

namespace UI.MainMenu
{
    public class AboutGameBTN : UIBTN
    {
        protected override void OnClick()
        {
            MainMenuEvents.AboutGameBtnUAction?.Invoke();
        }
    }
}