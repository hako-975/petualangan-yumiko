using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [HideInInspector]
    public int nextSceneLoad;
    
    AudioSource audioFinish;

    void Start()
    {
        audioFinish = GetComponent<AudioSource>();

        // + 1 sesuai urutan pada build index, level saat ini 1 dan build index nya 1 dan next level adalah level 2
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioFinish.Play();
            StartCoroutine(WaitDuration());
        }
    }

    IEnumerator WaitDuration()
    {
        yield return new WaitForSeconds(audioFinish.clip.length);
        
        int levelAt = PlayerPrefsManager.instance.GetLevelAt();

        // if retry level, not remove achievement
        if (PlayerPrefsManager.instance.GetBoolAchievementTemp() > 0)
        {
            PlayerPrefsManager.instance.SetBoolAchievementObject(SceneManager.GetActiveScene().buildIndex, 1);
        }

        // remove temp achievement
        PlayerPrefsManager.instance.RemoveBoolAchievementTemp();


        if (nextSceneLoad > levelAt)
        {
            PlayerPrefsManager.instance.SetLevelAt(nextSceneLoad);
        }

        PlayerPrefsManager.instance.SetCurrentLevel(0);

        PlayerPrefsManager.instance.SetNextScene("Level" + " " + nextSceneLoad);
    }
}
