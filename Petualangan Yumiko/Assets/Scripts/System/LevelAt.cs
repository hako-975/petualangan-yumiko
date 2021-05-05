using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelAt : MonoBehaviour
{
    public Button startGame;
    public Button continueGame;

    void Start()
    {
        if (PlayerPrefsManager.instance.GetLevelAt() == 0)
        {
            startGame.gameObject.SetActive(true);
            continueGame.gameObject.SetActive(false);
            startGame.onClick.AddListener(LevelAtScene);
        }
        else
        {
            startGame.gameObject.SetActive(false);
            continueGame.gameObject.SetActive(true);
            continueGame.onClick.AddListener(LevelAtScene);
        }
    }

    void LevelAtScene()
    {
        if (PlayerPrefsManager.instance.GetLevelAt() == 0)
        {
            PlayerPrefsManager.instance.SetNextScene("Level 1");
        }
        else
        {
            PlayerPrefsManager.instance.SetNextScene("Level" + " " + PlayerPrefsManager.instance.GetLevelAt());
        }
    }
}
