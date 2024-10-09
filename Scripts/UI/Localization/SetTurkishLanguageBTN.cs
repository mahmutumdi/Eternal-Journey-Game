using Events;
using Utilities;

namespace UI.Localization
{
    public class SetTurkishLanguageBTN : UIBTN
    {
        protected override void OnClick()
        {
            LocalizationEvents.SetTurkishLanguageBtnUAction?.Invoke();
        }
    }
}