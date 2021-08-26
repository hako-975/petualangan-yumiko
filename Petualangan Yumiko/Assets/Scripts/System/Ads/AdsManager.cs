using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
        private string gameId = "4101522";
#elif UNITY_ANDROID
    private string gameId = "4101523";
#endif

    bool testMode = true;
    string mySurfacingId = "rewardedVideo";

    public GameObject errorAdsPanel;

    PlayerStats playerStats;
    MenuManager menuManager;

    bool isFinishedAds = false;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        menuManager = FindObjectOfType<MenuManager>();

        // true is restart false is die
        Advertisement.AddListener(this);
        // Initialize the Ads service:
        Advertisement.Initialize(gameId, testMode);
    }

    public void RestartScene()
    {
        menuManager.Restart(false);
    }

    public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video");
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
            errorAdsPanel.SetActive(true);
        }
    }

    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(mySurfacingId))
        {
            PlayerPrefsManager.instance.SetLife(PlayerPrefsManager.instance.GetLife() + 1);
            PlayerPrefsManager.instance.SetHealth(4);
            Advertisement.Show(mySurfacingId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
            errorAdsPanel.SetActive(true);
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        if (surfacingId == "rewardedVideo")
        {
            // Define conditional logic for each ad completion status:
            if (showResult == ShowResult.Finished)
            {
                // Reward the user for watching the ad to completion.
            }
            else if (showResult == ShowResult.Skipped)
            {
                // Do not reward the user for skipping the ad.
            }
            else if (showResult == ShowResult.Failed)
            {
                Debug.LogWarning("The ad did not finish due to an error.");
                errorAdsPanel.SetActive(true);
            }
        }
        // interstitial ads
        else
        {
            if (showResult == ShowResult.Finished)
            {
                isFinishedAds = true;
            }
            else if (showResult == ShowResult.Skipped)
            {
                isFinishedAds = true;
                // Do not reward the user for skipping the ad.
            }
            else if (showResult == ShowResult.Failed)
            {
                isFinishedAds = true;
                errorAdsPanel.SetActive(true);
            }
            else
            {
                isFinishedAds = true;
            }

            if (isFinishedAds)
            {
                if (PlayerPrefsManager.instance.GetLife() < 0)
                {
                    // set current health 4
                    PlayerPrefsManager.instance.SetHealth(4);
                    PlayerPrefsManager.instance.SetLife(0);

                    playerStats.gameOverPanel.SetActive(true);

                    // reset spawn point
                    playerStats.spawnPoint.transform.position = new Vector3(0f, 0.05f, 0f);

                    // Time.timeScale = 1;
                }
                else
                {
                    menuManager.Restart(false);
                }
            }
            else
            {
                menuManager.Restart(false);
            }
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == mySurfacingId)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
