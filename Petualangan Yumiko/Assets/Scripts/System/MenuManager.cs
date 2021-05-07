using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(WaitLang());
    }

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
            // for button restart
            PlayerPrefsManager.instance.SetCurrentLevel(0);
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

    public void Gallery()
    {
        Time.timeScale = 1;
        // for loading
        PlayerPrefsManager.instance.SetNextScene("Gallery");
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

    IEnumerator WaitLang()
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[PlayerPrefsManager.instance.GetLanguage()];
    }

}
