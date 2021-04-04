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

    public int GetCurrentHealth()
    {
        return PlayerPrefs.GetInt("CurrentHealth");
    }

    public int SetCurrentHealth(int currentHealth)
    {
        PlayerPrefs.SetInt("CurrentHealth", currentHealth);
        return GetCurrentHealth();
    }    

    public float GetPositionX()
    {
        return PlayerPrefs.GetFloat("PositionX");
    }

    public float SetPositionX(float positionX)
    {
        PlayerPrefs.SetFloat("PositionX", positionX);
        return GetPositionX();
    }

    public float GetPositionY()
    {
        return PlayerPrefs.GetFloat("PositionY");
    }

    public float SetPositionY(float positionY)
    {
        PlayerPrefs.SetFloat("PositionY", positionY);
        return GetPositionY();
    }

    public float GetPositionZ()
    {
        return PlayerPrefs.GetFloat("PositionZ");
    }

    public float SetPositionZ(float positionZ)
    {
        PlayerPrefs.SetFloat("PositionZ", positionZ);
        return GetPositionZ();
    }

    public int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("CurrentLevel");
    }

    public int SetCurrentLevel(int level)
    {
        PlayerPrefs.SetInt("CurrentLevel", level);
        return GetCurrentLevel();
    }

    public int GetLife()
    {
        return PlayerPrefs.GetInt("Life", 3);
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
        return PlayerPrefs.GetFloat("SFX", -5f);
    }

    public float SetSFX(float volumeSFX)
    {
        PlayerPrefs.SetFloat("SFX", volumeSFX);
        return GetSFX();
    }

    public float GetMusic()
    {
        return PlayerPrefs.GetFloat("Music", -5f);
    }

    public float SetMusic(float volumeMusic)
    {
        PlayerPrefs.SetFloat("Music", volumeMusic);
        return GetMusic();
    }

    public float GetSensitivity()
    {
        return PlayerPrefs.GetFloat("Sensitivity", 20f);
    }

    public float SetSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        return GetSensitivity();
    }

    public int GetQuality()
    {
        return PlayerPrefs.GetInt("QualityIndex", 0);
    }

    public int SetQuality(int qualityIndex)
    {
        PlayerPrefs.SetInt("QualityIndex", qualityIndex);
        return GetQuality();
    }

    public string GetNextScene()
    {
        return PlayerPrefs.GetString("NextScene", "Main Menu");
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
