using System;
using Events;
using Monetization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

namespace UI.MainMenu
{
    public class MainMenuManager : EventListenerMono
    {
        [SerializeField] private GameObject _aboutGamePanel;
        [SerializeField] private RewardedAds _rewardedAds;
        [SerializeField] private ToggleGroup _toggleGroup;
        [SerializeField] private string _selectedCharacterName;

        private void Awake()
        {
            _aboutGamePanel.SetActive(false);
        }

        private void Start()
        {
            // Add listener to each toggle in the toggle group
            foreach (Toggle toggle in _toggleGroup.GetComponentsInChildren<Toggle>())
            {
                toggle.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggle); });
            }
        
            Toggle selectedToggle = _toggleGroup.GetFirstActiveToggle();
            if (selectedToggle != null)
            {
                _selectedCharacterName = selectedToggle.gameObject.name;
            }
        }

        private void OnToggleValueChanged(Toggle toggle)
        {
            if (toggle.isOn)
            {
                _selectedCharacterName = toggle.gameObject.name;
            }
        }
        
        protected override void RegisterEvents()
        {
            MainMenuEvents.StartGameBtnUAction += OnStartGameBTN;
            MainMenuEvents.AboutGameBtnUAction += OnAboutGameBTN;
            MainMenuEvents.SupportDeveloperBtnUAction += OnSupportDeveloperBTN;
            MainMenuEvents.ExitAboutGameBtnUAction += OnExitAboutGameBTN;
            
        }

        private void OnSupportDeveloperBTN()
        {
            if (_rewardedAds != null)
            {
                _rewardedAds.LoadAd();
            }
            else
            {
                Debug.LogError("Ads script not found.");
            }
        }

        private void OnAboutGameBTN()
        {
            _aboutGamePanel.SetActive(true);
        }

        private void OnExitAboutGameBTN()
        {
            _aboutGamePanel.SetActive(false);
            
        }

        private void OnStartGameBTN()
        {
            PlayerPrefs.SetString("SelectedCharacterName", _selectedCharacterName);
        
            Debug.Log("Selected: " + _selectedCharacterName);

            SceneManager.LoadScene("GameScene");
        }

        protected override void UnRegisterEvents()
        {
            MainMenuEvents.StartGameBtnUAction -= OnStartGameBTN;
            MainMenuEvents.AboutGameBtnUAction -= OnAboutGameBTN;
            MainMenuEvents.SupportDeveloperBtnUAction -= OnSupportDeveloperBTN;
            MainMenuEvents.ExitAboutGameBtnUAction -= OnExitAboutGameBTN;
        }
    }
}