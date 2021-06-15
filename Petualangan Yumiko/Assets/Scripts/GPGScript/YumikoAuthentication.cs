using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class YumikoAuthentication : MonoBehaviour
{
    public static PlayGamesPlatform platform;

    public GameObject googlePanelSuccess;
    public GameObject googlePanelFailed;

    private void Start()
    {
        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;

            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                googlePanelSuccess.gameObject.SetActive(true);
            }
            else
            {
                googlePanelFailed.gameObject.SetActive(true);
            }
        });
    }

    public void Authentication()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;

        platform = PlayGamesPlatform.Activate();

        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                googlePanelSuccess.gameObject.SetActive(true);
            }
            else
            {
                googlePanelFailed.gameObject.SetActive(true);
            }
        });
    }
}
