using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace UI.LoginMenu
{
    public class LoginMenuController : MonoBehaviour
    {
        [SerializeField] private VideoPlayer _studioVideoPlayer;
        void Start()
        {
            if (SceneManager.GetActiveScene().name == "LoginScene")
            {
                _studioVideoPlayer.loopPointReached += OnVideoEnd;
            }
        }

        private void OnVideoEnd(VideoPlayer vp)
        {
            GoToMainMenu();
        }

        private static void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    
        private void OnDestroy()
        {
            if (_studioVideoPlayer != null)
            {
                _studioVideoPlayer.loopPointReached -= OnVideoEnd;
            }
        }
    }
}