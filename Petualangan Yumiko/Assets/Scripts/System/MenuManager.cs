using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource buttonUIClick;
    public AudioSource backButtonUIClick;
    AdsManager adsManager;
    TimerManager timerManager;

    private void Awake()
    {
        StartCoroutine(WaitLang());
    }

    private void Start()
    {
        adsManager = FindObjectOfType<AdsManager>();
        timerManager = FindObjectOfType<TimerManager>();
    }

    public void Paused()
    {
        buttonUIClick.Play();
        Time.timeScale = 0;
    }

    public void Resume()
    {
        buttonUIClick.Play();
        Time.timeScale = 1;
    }

    public void Restart(bool restart)
    {
        buttonUIClick.Play();

        if (restart)
        {
            Time.timeScale = 0;

            // reset timer
            timerManager.finished = true;
            PlayerPrefsManager.instance.SetTimer(0);
            PlayerPrefsManager.instance.DeleteKey("Timer");

            // for button restart
            PlayerPrefsManager.instance.SetCurrentLevel(0);

            // remove temp achievement
            PlayerPrefsManager.instance.RemoveBoolAchievementTemp();
            
            // ads
            adsManager.ShowInterstitialAd();
        }
        else
        {
            Time.timeScale = 1;
            Scene scene = SceneManager.GetActiveScene();

            // for loading
            PlayerPrefsManager.instance.SetNextScene(scene.name);
        }
    }

    public void SelectLevel()
    {
        buttonUIClick.Play();
        Time.timeScale = 1;
        // for loading
        PlayerPrefsManager.instance.SetNextScene("Select Level");
    }

    public void Gallery()
    {
        buttonUIClick.Play();

        Time.timeScale = 1;
        // for loading
        PlayerPrefsManager.instance.SetNextScene("Gallery");
    }    

    public void MainMenu()
    {
        buttonUIClick.Play();

        Time.timeScale = 1;
        
        // remove temp achievement
        PlayerPrefsManager.instance.RemoveBoolAchievementTemp();

        // for loading
        PlayerPrefsManager.instance.SetNextScene("Main Menu");
    }

    public void Quit()
    {
        buttonUIClick.Play();

        Time.timeScale = 1;
        
        // remove temp achievement
        PlayerPrefsManager.instance.RemoveBoolAchievementTemp();

        Application.Quit();
        Debug.Log("Keluar dari permainan!");
    }

    public void PlayButtonUIClickSFX()
    {
        buttonUIClick.Play();
    }

    public void PlayBackButtonSFX()
    {
        backButtonUIClick.Play();
    }

    IEnumerator WaitLang()
    {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[PlayerPrefsManager.instance.GetLanguage()];
    }
}
