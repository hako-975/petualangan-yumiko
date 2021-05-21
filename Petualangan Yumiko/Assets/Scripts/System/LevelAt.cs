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
            startGame.onClick.AddListener(LevelAtSceneStartGame);
        }
        else
        {
            startGame.gameObject.SetActive(false);
            continueGame.gameObject.SetActive(true);
            continueGame.onClick.AddListener(LevelAtSceneContinueGame);
        }
    }

    void LevelAtSceneStartGame()
    {
        StartCoroutine(WaitDurationSFXStartGame());
    }

    void LevelAtSceneContinueGame()
    {
        StartCoroutine(WaitDurationSFXContinueGame());
    }

    IEnumerator WaitDurationSFXStartGame()
    {
        yield return new WaitForSeconds(startGame.GetComponent<AudioSource>().clip.length);
        PlayerPrefsManager.instance.SetNextScene("Level 1");
    }

    IEnumerator WaitDurationSFXContinueGame()
    {
        yield return new WaitForSeconds(continueGame.GetComponent<AudioSource>().clip.length);
        PlayerPrefsManager.instance.SetNextScene("Level" + " " + PlayerPrefsManager.instance.GetLevelAt());
    }
}
