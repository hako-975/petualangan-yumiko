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


    public void Authentication()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
        // enables saving game progress.
        .EnableSavedGames()
        // requests the email address of the player be available.
        // Will bring up a prompt for consent.
        .RequestEmail()
        // requests a server auth code be generated so it can be passed to an
        //  associated back end server application and exchanged for an OAuth token.
        .RequestServerAuthCode(false)
        // requests an ID token be generated.  This OAuth token can be used to
        //  identify the player to other services such as Firebase.
        .RequestIdToken()
        .Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

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
