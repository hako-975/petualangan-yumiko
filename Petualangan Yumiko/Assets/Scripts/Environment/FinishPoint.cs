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

            Debug.Log("Timer: " + PlayerPrefsManager.instance.GetTimer());

            // get and set timer score
            if (PlayerPrefsManager.instance.GetTimer() < PlayerPrefsManager.instance.GetTimerScore(SceneManager.GetActiveScene().buildIndex))
            {
                switch(SceneManager.GetActiveScene().buildIndex)
                {
                    case 1:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel1((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("1: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 2:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel2((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("2: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 3:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel3((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("3: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 4:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel4((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("4: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 5:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel5((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("5: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 6:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel6((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("6: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 7:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel7((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("7: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 8:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel8((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("8: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 9:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel9((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("9: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 10:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel10((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("10: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 11:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel11((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("11: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 12:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel12((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("12: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 13:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel13((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("13: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 14:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel14((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("14: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        break;
                    case 15:
                        PlayerPrefsManager.instance.SetTimerScore(SceneManager.GetActiveScene().buildIndex, PlayerPrefsManager.instance.GetTimer());
                        yumikoLeaderboards.UpdateLeaderboardScoreLevel15((int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
                        Debug.Log("15: " + (int)(PlayerPrefsManager.instance.GetTimer() * 1000f));
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
