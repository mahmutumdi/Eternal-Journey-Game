using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

namespace Monetization
{
    public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        [SerializeField] Toggle[] _adToggles;
        [SerializeField] Sprite _defaultSprite;
        [SerializeField] Sprite[] _rewardedSprites;
        [SerializeField] string _androidAdUnitId = "Rewarded_Android";
        [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
        private string _adUnitId = null; // This should remain null for unsupported platforms

        void Awake()
        {
            if (_rewardedSprites == null || _rewardedSprites.Length == 0)
            {
                Debug.LogError("Rewarded Sprites array is not assigned or empty!");
                return;
            }

#if UNITY_IOS
            _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
            _adUnitId = _androidAdUnitId;
#endif

            for (int i = 0; i < _adToggles.Length; i++)
            {
                int index = i;
                _adToggles[i].onValueChanged.AddListener(delegate { OnToggleClicked(index); });
                UpdateToggleSprite(index); // Update sprite on startup
            }
        }

        private void OnToggleClicked(int index)
        {
            if (_adToggles[index].isOn && PlayerPrefs.GetInt($"AdShown_{index}", 0) == 0)
            {
                PlayerPrefs.SetInt("CurrentAdIndex", index);
                LoadAd();
            }
        }

        public void LoadAd()
        {
            Debug.Log("Loading Ad: " + _adUnitId);
            Advertisement.Load(_adUnitId, this);
        }

        public void OnUnityAdsAdLoaded(string adUnitId)
        {
            Debug.Log("Ad Loaded: " + adUnitId);

            if (adUnitId.Equals(_adUnitId))
            {
                ShowAd();
            }
        }

        public void ShowAd()
        {
            Advertisement.Show(_adUnitId, this);
        }

        public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
        {
            if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
            {
                Debug.Log("Unity Ads Rewarded Ad Completed");

                // Retrieve and use the saved index to update PlayerPrefs
                int index = PlayerPrefs.GetInt("CurrentAdIndex", -1);
                if (index != -1)
                {
                    PlayerPrefs.SetInt($"AdShown_{index}", 1); // Save state
                    UpdateToggleSprite(index); // Update sprite after ad is shown
                }
            }
        }

        public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
        {
            Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        }

        public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
        {
            Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        }

        public void OnUnityAdsShowStart(string adUnitId) { }
        public void OnUnityAdsShowClick(string adUnitId) { }

        void OnDestroy()
        {
            foreach (var toggle in _adToggles)
            {
                toggle.onValueChanged.RemoveAllListeners();
            }
        }

        private void UpdateToggleSprite(int index)
        {
            if (index < 0 || index >= _adToggles.Length)
            {
                Debug.LogError($"Index {index} is out of bounds for the toggle array.");
                return;
            }

            Image toggleImage = _adToggles[index].GetComponentInChildren<Image>();
            if (toggleImage == null)
            {
                Debug.LogError($"Toggle at index {index} does not have an Image component in its children.");
                return;
            }

            if (PlayerPrefs.GetInt($"AdShown_{index}", 0) == 0)
            {
                toggleImage.sprite = _defaultSprite;
            }
            else
            {
                if (index < _rewardedSprites.Length)
                {
                    toggleImage.sprite = _rewardedSprites[index];
                }
                else
                {
                    Debug.LogError($"No rewarded sprite found for index {index}.");
                }
            }
        }

    }
}
