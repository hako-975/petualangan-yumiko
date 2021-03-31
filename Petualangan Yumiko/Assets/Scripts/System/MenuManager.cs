using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Paused()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Restart(bool restart)
    {
        if (restart)
        {
            // do not change PlayerPrefs.SetInt("CurrentLevel", 0);
            // for button restart
            PlayerPrefs.SetInt("CurrentLevel", 0);
        }

        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();

        // for loading
        PlayerPrefsManager.instance.SetNextScene(scene.name);
    }

    public void SelectLevel()
    {
        Time.timeScale = 1;
        // for loading
        PlayerPrefsManager.instance.SetNextScene("Select Level");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        // for loading
        PlayerPrefsManager.instance.SetNextScene("Main Menu");
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
        Debug.Log("Keluar dari permainan!");
    }
}
