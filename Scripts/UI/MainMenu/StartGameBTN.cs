using Events;
using Utilities;

namespace UI.MainMenu
{
    public class StartGameBTN : UIBTN
    {
        protected override void OnClick()
        {
            MainMenuEvents.StartGameBtnUAction?.Invoke();
        }
    }
}