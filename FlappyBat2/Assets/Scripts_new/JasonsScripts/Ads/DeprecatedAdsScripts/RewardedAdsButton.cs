using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms

    [SerializeField] Button _showAdButtonCheat;
    public CheatScript cheatScript;
    private bool CheatReward = false;


    [SerializeField] Button _showAdButtonLeaderBoard;
    public LeaderBoardController leaderBoardController;
    private bool SubmitScoreReward = false;


    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        //Disable the button until the ad is ready to show:
        _showAdButtonCheat.interactable = false;
        _showAdButtonLeaderBoard.interactable = false;

    }

    public void ActivateButton() // Manually activate button
    {
        _showAdButtonCheat.interactable = true;
        _showAdButtonLeaderBoard.interactable = true;

    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            _showAdButtonCheat.onClick.AddListener(ShowAdCheat);
            _showAdButtonLeaderBoard.onClick.AddListener(ShowAdLeaderBoard);

            // Enable the button for users to click:
            _showAdButtonCheat.interactable = true;
            _showAdButtonLeaderBoard.interactable = true;
        }
    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAdCheat()
    {
        // Indicate reward:
        CheatReward = true;

        // Disable the button:
        _showAdButtonCheat.interactable = false;
        _showAdButtonLeaderBoard.interactable = false;

        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAdLeaderBoard()
    {
        // Indicate reward:
        SubmitScoreReward = true;

        // Disable the button:
        _showAdButtonCheat.interactable = false;
        _showAdButtonLeaderBoard.interactable = false;

        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.

            if(CheatReward == true)
            {
                Debug.Log("Cheat Reward");
                cheatScript.AddOneToHighScore();
                CheatReward = false;
                // Load another ad:
                Advertisement.Load(_adUnitId, this);
            }
            else if(SubmitScoreReward == true)
            {
                Debug.Log("Submit Score Reward");
                leaderBoardController.SubmitScore();
                SubmitScoreReward = false;
                // Load another ad:
                Advertisement.Load(_adUnitId, this);
            }
            else
            {
                Debug.Log("No reward indicated");
                SubmitScoreReward = false;
                CheatReward = false;
            }


        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        _showAdButtonCheat.onClick.RemoveAllListeners();
        _showAdButtonLeaderBoard.onClick.RemoveAllListeners();

    }
}