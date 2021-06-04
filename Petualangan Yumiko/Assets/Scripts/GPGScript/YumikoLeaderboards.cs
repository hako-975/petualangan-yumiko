using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YumikoLeaderboards : MonoBehaviour
{
    public void OpenLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

    public void UpdateLeaderboardScoreLevel1(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_1, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel2(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_2, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel3(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_3, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel4(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_4, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel5(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_5, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel6(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_6, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel7(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_7, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel8(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_8, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel9(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_9, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel10(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_10, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel11(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_11, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel12(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_12, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel13(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_13, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel14(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_14, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }

    public void UpdateLeaderboardScoreLevel15(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_timer_level_15, (bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
            }
        });
    }
}
