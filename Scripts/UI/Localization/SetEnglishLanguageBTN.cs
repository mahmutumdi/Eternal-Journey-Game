using Events;
using Utilities;

namespace UI.Localization
{
    public class SetEnglishLanguageBTN : UIBTN
    {
        protected override void OnClick()
        {
            LocalizationEvents.SetEnglishLanguageBtnUAction?.Invoke();
        }
    }
}