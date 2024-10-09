using System;
using Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UI.GameMenu
{
    public class GameMenuManager : EventListenerMono
    {
        [SerializeField] private TextMeshProUGUI _gameScoreTMP;
        [SerializeField] private Button _pauseButton;
        [SerializeField] private GameObject _gameMenuPanel;
        [SerializeField] private Button _continueButton;
        [SerializeField] private AudioSource _musicAudioSource;
        // [SerializeField] private Button _replayButton;
        // [SerializeField] private Button _mainMenuButton;
        // [SerializeField] private Slider _musicSlider;
        
        public float MusicVal => _musicVal;
        private const string MusicPrefKey = "Music";
        private float _musicVal;

        private float _playerScore;
        private bool _isPlayerAlive;

        private static GameMenuManager _instance;

        public static GameMenuManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameMenuManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("GameMenuManager");
                        _instance = go.AddComponent<GameMenuManager>();
                    }
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
            _musicVal = PlayerPrefs.GetFloat(MusicPrefKey);
        
            _playerScore = 0;
            _isPlayerAlive = true;
            _musicAudioSource.volume = GameMenuManager.Instance.MusicVal;
        
        }
        
        private void Update()
        {
            if (_isPlayerAlive)
            {
                _playerScore += Time.deltaTime * 1;
                if (_gameScoreTMP != null)
                {
                    _gameScoreTMP.text = "Score: " + _playerScore.ToString("F");
                }
            }
        }

        public void SetPlayerAlive(bool isAlive)
        {
            _isPlayerAlive = isAlive;
        }

        public void DisplayGameOver()
        {
            if (_gameScoreTMP != null)
            {
                _gameScoreTMP.text = "Game Over!\n" + "Your score: " + _playerScore.ToString("F");
                _pauseButton.gameObject.SetActive(false);
                _gameMenuPanel.SetActive(true);
                _continueButton.gameObject.SetActive(false);
                _musicAudioSource.Stop();
            }
        }

        protected override void RegisterEvents()
        {
            GameMenuEvents.PauseGameBtnUAction += OnPauseGameBTN;
            GameMenuEvents.ContinueGameBtnUAction += OnContinueGameBTN;
            GameMenuEvents.ReplayGameBtnUAction += OnReplayGameBTN;
            GameMenuEvents.GoMainMenuBtnUAction += OnGoMainMenuBTN;
            GameMenuEvents.MusicSliderUAction += MusicValueCHANGED;
        }
        
        private void MusicValueCHANGED(float musicVal)
        {
            _musicVal = musicVal;
            PlayerPrefs.SetFloat(MusicPrefKey, _musicVal);
            
            _musicAudioSource.volume = musicVal;
        }
        
        private void OnPauseGameBTN()
        {
            _musicAudioSource.Pause();
            Time.timeScale = 0;
            _pauseButton.gameObject.SetActive(false);
            _gameMenuPanel.SetActive(true);
        }
    
        private void OnContinueGameBTN()
        {
            _musicAudioSource.UnPause();
            Time.timeScale = 1; 
            _pauseButton.gameObject.SetActive(true);
            _gameMenuPanel.SetActive(false);
        }

        private void OnReplayGameBTN()
        {
            _musicAudioSource.Play();
            Time.timeScale = 1;
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        private void OnGoMainMenuBTN()
        {
            Time.timeScale = 1;
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
        }

        protected override void UnRegisterEvents()
        {
            GameMenuEvents.PauseGameBtnUAction -= OnPauseGameBTN;
            GameMenuEvents.ContinueGameBtnUAction -= OnContinueGameBTN;
            GameMenuEvents.ReplayGameBtnUAction -= OnReplayGameBTN;
            GameMenuEvents.GoMainMenuBtnUAction -= OnGoMainMenuBTN;
            GameMenuEvents.MusicSliderUAction -= MusicValueCHANGED;
        }
    }
}