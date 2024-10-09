using Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UI.Localization
{
    public class LanguageTest : EventListenerMono
    {
        public TMP_Text[] translatedTexts;
        public string[] translationKeys;

        void Start()
        {
            // Set default language to the saved preference
            LocalizationManager.Instance.SetLanguage((Languages)PlayerPrefs.GetInt("Language", (int)Languages.English));
            UpdateTexts();
        }

        public void OnSetTurkishLanguageBTN()
        {
            LocalizationManager.Instance.SetLanguage(Languages.Turkish);
            UpdateTexts();
        }

        public void OnSetEnglishLanguageBTN()
        {
            LocalizationManager.Instance.SetLanguage(Languages.English);
            UpdateTexts();
        }

        void UpdateTexts()
        {
            for (int i = 0; i < translatedTexts.Length; i++)
            {
                translatedTexts[i].text = LocalizationManager.Instance.GetTranslation(translationKeys[i]);
            }
        }

        protected override void RegisterEvents()
        {
            LocalizationEvents.SetEnglishLanguageBtnUAction += OnSetEnglishLanguageBTN;
            LocalizationEvents.SetTurkishLanguageBtnUAction += OnSetTurkishLanguageBTN;
        }

        protected override void UnRegisterEvents()
        {
            LocalizationEvents.SetEnglishLanguageBtnUAction -= OnSetEnglishLanguageBTN;
            LocalizationEvents.SetTurkishLanguageBtnUAction -= OnSetTurkishLanguageBTN;
        }
    }
}