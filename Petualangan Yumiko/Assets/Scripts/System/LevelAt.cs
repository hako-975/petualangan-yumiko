using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelAt : MonoBehaviour
{
    public Button startGame;
    public Button resumeGame;

    void Start()
    {
        if (PlayerPrefsManager.instance.GetLevelAt() == 0)
        {
            startGame.gameObject.SetActive(true);
            resumeGame.gameObject.SetActive(false);
            startGame.onClick.AddListener(LevelAtScene);
        }
        else
        {
            startGame.gameObject.SetActive(false);
            resumeGame.gameObject.SetActive(true);
            resumeGame.onClick.AddListener(LevelAtScene);
        }
    }

    void LevelAtScene()
    {
        if (PlayerPrefsManager.instance.GetLevelAt() == 0)
        {
            SceneManager.LoadScene("Level 1");
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefsManager.instance.GetLevelAt());
        }
    }
}
