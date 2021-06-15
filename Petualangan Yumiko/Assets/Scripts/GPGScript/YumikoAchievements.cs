using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class YumikoAchievements : MonoBehaviour
{
    public static PlayGamesPlatform platform;

    YumikoAuthentication yumikoAuthentication;

    private void Start()
    {
        yumikoAuthentication = FindObjectOfType<YumikoAuthentication>();
    }

    public void OpenAchievementPanel()
    {
        if (platform != null)
        {
            Social.ShowAchievementsUI();
        }
        else
        {
            yumikoAuthentication.Authentication();
            Social.ShowAchievementsUI();
        }
    }

    public void UnlockedAchievement(int level)
    {
        switch(level)
        {
            case 1:
                Social.ReportProgress(GPGSIds.achievement_apple, 100f, null);
                break;
            case 2:
                Social.ReportProgress(GPGSIds.achievement_banana, 100f, null);
                break;
            case 3:
                Social.ReportProgress(GPGSIds.achievement_cherry, 100f, null);
                break;
            case 4:
                Social.ReportProgress(GPGSIds.achievement_durian, 100f, null);
                break;
            case 5:
                Social.ReportProgress(GPGSIds.achievement_eggplant, 100f, null);
                break;
            case 6:
                Social.ReportProgress(GPGSIds.achievement_fig, 100f, null);
                break;
            case 7:
                Social.ReportProgress(GPGSIds.achievement_grape, 100f, null);
                break;
            case 8:
                Social.ReportProgress(GPGSIds.achievement_honeydew, 100f, null);
                break;
            case 9:
                Social.ReportProgress(GPGSIds.achievement_illawarra_plum, 100f, null);
                break;
            case 10:
                Social.ReportProgress(GPGSIds.achievement_jalapeno, 100f, null);
                break;
            case 11:
                Social.ReportProgress(GPGSIds.achievement_kiwi, 100f, null);
                break;
            case 12:
                Social.ReportProgress(GPGSIds.achievement_lemon, 100f, null);
                break;
            case 13:
                Social.ReportProgress(GPGSIds.achievement_mango, 100f, null);
                break;
            case 14:
                Social.ReportProgress(GPGSIds.achievement_nectarine, 100f, null);
                break;
            case 15:
                Social.ReportProgress(GPGSIds.achievement_orange, 100f, null);
                break;
        }
    }

}
