using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer_new : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    public RewardedAdsButton adsManager;

    void Awake()
    {
        Debug.Log("Unity Ads initializating.");
        InitializeAds();
    }

    public void InitializeAds()
    {
        // Get the Game ID for the current platform:
#if UNITY_IOS
        _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
        _gameId = _iOSGameId;
#endif

        Advertisement.Initialize(_gameId, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        adsManager.LoadAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}