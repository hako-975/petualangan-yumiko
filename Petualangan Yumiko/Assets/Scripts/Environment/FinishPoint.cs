using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [HideInInspector]
    public int nextSceneLoad;
    
    AudioSource audioFinish;

    bool isEntered = false;

    TimerManager timerManager;

    YumikoLeaderboards yumikoLeaderboards;
    YumikoAchievements yumikoAchievements;

    void Start()
    {
        yumikoLeaderboards = FindObjectOfType<YumikoLeaderboards>();
        yumikoAchievements = FindObjectOfType<YumikoAchievements>();
        audioFinish = GetComponent<AudioSource>();
        timerManager = FindObjectOfType<TimerManager>();

        // + 1 sesuai urutan pada build index, level saat ini 1 dan build index nya 1 dan next level adalah level 2
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void Update()
    {
        if (!isEntered)
        {
            audioFinish.pitch -= 0.01f;
        }
        else
        {
            audioFinish.pitch = 1f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timerManager.Finish();

            isEntered = true;
            audioFinish.Play();
            StartCoroutine(WaitDuration());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEntered = false;
        }
    }

    IEnumerator WaitDuration()
    {
        yield return new WaitForSeconds(audioFinish.clip.length);

        if (isEntered == true)
        {
            int levelAt = PlayerPrefsManager.instance.GetLevelAt();

            // if get achievement
            if (PlayerPrefsManager.instance.GetBoolAchievementTemp() > 0)
            {
                yumikoAchievements.UnlockedAchievement(SceneManager.GetActiveScene().buildIndex);
                PlayerPrefsManager.instance.SetBoolAchievementObject(SceneManager.GetActiveScene().buildIndex, 1);
            }


            // 100 millisecond
            if (PlayerPrefsManager.instance.GetTimerLevel(SceneManager.GetActiveScene().buildIndex) < 1000)
            {
                PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, 999999999999f);
            }

            // get and set timer score
            if (PlayerPrefsManager.instance.GetTimerFinish() < PlayerPrefsManager.instance.GetTimerLevel(SceneManager.GetActiveScene().buildIndex))
            {
                switch (SceneManager.GetActiveScene().buildIndex)
                {
                    case 1:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel1(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 2:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel2(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 3:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel3(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 4:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel4(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 5:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel5(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 6:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel6(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 7:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel7(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 8:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel8(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 9:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel9(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 10:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel10(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 11:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel11(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 12:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel12(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 13:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel13(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 14:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel14(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                    case 15:
                        PlayerPrefsManager.instance.SetTimerLevel(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimerFinish());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel15(PlayerPrefsManager.instance.GetTimerFinish());
                        break;
                }
            }
     
            // remove temp achievement
            PlayerPrefsManager.instance.RemoveBoolAchievementTemp();

            // reset timer
            PlayerPrefsManager.instance.DeleteKey("Timer");

            if (nextSceneLoad > levelAt)
            {
                PlayerPrefsManager.instance.SetLevelAt(nextSceneLoad);
            }

            PlayerPrefsManager.instance.SetCurrentLevel(0);

            PlayerPrefsManager.instance.SetNextScene("Level" + " " + nextSceneLoad);
        }
    }
}
