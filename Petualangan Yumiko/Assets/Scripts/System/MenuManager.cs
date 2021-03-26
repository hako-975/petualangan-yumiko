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

    public void Restart()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        PlayerPrefsManager.instance.SetNextScene(scene.name);
    }

    public void SelectLevel()
    {
        Time.timeScale = 1;
        PlayerPrefsManager.instance.SetNextScene("Select Level");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        PlayerPrefsManager.instance.SetNextScene("Main Menu");
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
        Debug.Log("Keluar dari permainan!");
    }
}
