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

    void Start()
    {
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
                PlayerPrefsManager.instance.SetBoolAchievementObject(SceneManager.GetActiveScene().buildIndex, 1);
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
