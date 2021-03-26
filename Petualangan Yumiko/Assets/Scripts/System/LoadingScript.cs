using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    public Image image;

    void Start()
    {
        if (PlayerPrefsManager.instance.GetNextScene() == "")
        {
            PlayerPrefsManager.instance.SetNextScene("Main Menu");
        }
        else
        {
            StartCoroutine(LoadAsync(PlayerPrefsManager.instance.GetNextScene()));
        }
    }

    IEnumerator LoadAsync(string nextScene)
    {
        AsyncOperation sync = SceneManager.LoadSceneAsync(nextScene);
        while (!sync.isDone)
        {
            float progress = Mathf.Clamp01(sync.progress);
            image.fillAmount -= progress;
            yield return new WaitForEndOfFrame();   
        }  
    }
}
