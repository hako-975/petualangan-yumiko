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
        StartCoroutine(LoadAsync(PlayerPrefsManager.instance.GetNextScene()));
    }

    IEnumerator LoadAsync(string nextScene)
    {
        AsyncOperation sync = SceneManager.LoadSceneAsync(nextScene);
        if (sync == null)
        {
            SceneManager.LoadScene("Coming Soon");
        }
        else
        {
            while (!sync.isDone)
            {
                float progress = Mathf.Clamp01(sync.progress);
                image.fillAmount -= progress;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
