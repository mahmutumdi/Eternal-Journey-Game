using Events;
using Utilities;

namespace UI.MainMenu
{
    public class ExitAboutGameBTN : UIBTN
    {
        protected override void OnClick()
        {
            MainMenuEvents.ExitAboutGameBtnUAction?.Invoke();
        }
    }
}