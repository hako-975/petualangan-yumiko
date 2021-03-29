using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    #region Singleton
    public static PlayerPrefsManager instance;
    
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("CurrentLevel");
    }

    public int SetCurrentLevel(int level)
    {
        PlayerPrefs.SetInt("CurrentLevel", level);
        return GetCurrentLevel();
    }

    public int GetFirstPlayingForLife()
    {
        return PlayerPrefs.GetInt("FirstPlayingForLife");
    }

    public int SetFirstPlayingForLife(int boolean)
    {
        PlayerPrefs.SetInt("FirstPlayingForLife", boolean);
        return boolean;
    }

    public int GetLife()
    {
        return PlayerPrefs.GetInt("Life");
    }    

    public int SetLife(int life)
    {
        PlayerPrefs.SetInt("Life", life);
        return GetLife();
    }

    public int DecreaseLife()
    {
        int currentLife = GetLife() - 1;
        PlayerPrefs.SetInt("Life", currentLife);
        return GetLife();
    }

    public int GetLevelAt()
    {
        return PlayerPrefs.GetInt("LevelAt");
    }

    public int SetLevelAt(int level)
    {
        PlayerPrefs.SetInt("LevelAt", level);
        return GetLevelAt();
    }

    public float GetSFX()
    {
        return PlayerPrefs.GetFloat("SFX");
    }

    public float SetSFX(float volumeSFX)
    {
        PlayerPrefs.SetFloat("SFX", volumeSFX);
        return GetSFX();
    }

    public float GetMusic()
    {
        return PlayerPrefs.GetFloat("Music");
    }

    public float SetMusic(float volumeMusic)
    {
        PlayerPrefs.SetFloat("Music", volumeMusic);
        return GetMusic();
    }

    public float GetSensitivity()
    {
        return PlayerPrefs.GetFloat("Sensitivity");
    }

    public float SetSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        return GetSensitivity();
    }

    public int GetQuality()
    {
        return PlayerPrefs.GetInt("QualityIndex");
    }

    public int SetQuality(int qualityIndex)
    {
        PlayerPrefs.SetInt("QualityIndex", qualityIndex);
        return GetQuality();
    }

    public string GetNextScene()
    {
        return PlayerPrefs.GetString("NextScene");
    }

    public void SetNextScene(string nextScene)
    {
        PlayerPrefs.SetString("NextScene", nextScene);
        SceneManager.LoadScene("Loading");
    }

    public void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
}
