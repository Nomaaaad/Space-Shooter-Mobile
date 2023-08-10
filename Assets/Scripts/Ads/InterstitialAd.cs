using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";

    [SerializeField] private int timeToSkip = 1;

    string _adUnitId;



    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        //_adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
        //    ? _iOsAdUnitId
        //    : _androidAdUnitId;

#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
        int skipNumber = PlayerPrefs.GetInt("Interstitial", timeToSkip);
        if (skipNumber != 0)
        {
            skipNumber--;
            PlayerPrefs.SetInt("Interstitial", skipNumber);
        }
        else
        {
            LoadAd();
            PlayerPrefs.SetInt("Interstitial", timeToSkip);
        }
    }

    public void LoadAd()
    {
        if (Advertisement.isInitialized)
            Advertisement.Load(_adUnitId, this);
    }

    public void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        ShowAd();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Failed To Load");
    }

    public void OnUnityAdsShowClick(string placementId)
    {

    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Time.timeScale = 1;
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Time.timeScale = 0;
    }
}
