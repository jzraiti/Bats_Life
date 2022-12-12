using Unity.Advertisement.IosSupport;
using UnityEngine;

public class AppleATTManager : MonoBehaviour
{
    void Start()
    {
        RequestTrackingPermission();
    }

    public void RequestTrackingPermission()
    {
#if UNITY_IOS
        Debug.Log("Unity iOS Support: Checking tracking auth status.");

        if (ATTrackingStatusBinding.GetAuthorizationTrackingStatus() == ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
        {
            Debug.Log("Unity iOS Support: Requesting iOS App Tracking Transparency native dialog.");
            ATTrackingStatusBinding.RequestAuthorizationTracking();
        }
#endif
    }
}
