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
    
    public void RemoveExtraLifeBoolean()
    {
        for (int i = 1; i <= 100; i++)
        {
            PlayerPrefs.DeleteKey("ExtraLifeToBoolean" + i);
        }
    }

    public int GetExtraLifeToBoolean(int extraLifeTo)
    {
        return PlayerPrefs.GetInt("ExtraLifeToBoolean" + extraLifeTo, 0);
    }

    public void SetExtraLifeToBoolean(int extraLifeTo)
    {
        PlayerPrefs.SetInt("ExtraLifeToBoolean" + extraLifeTo, 1);
    }

    public int GetCurrentHealth()
    {
        return PlayerPrefs.GetInt("CurrentHealth", 4);
    }

    public int SetCurrentHealth(int currentHealth)
    {
        PlayerPrefs.SetInt("CurrentHealth", currentHealth);
        return GetCurrentHealth();
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

    public float GetZoom()
    {
        return PlayerPrefs.GetFloat("Zoom", 50);
    }

    public float SetZoom(float zoom)
    {
        PlayerPrefs.SetFloat("Zoom", zoom);
        return GetZoom();
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

    public int GetComingSoon()
    {
        return PlayerPrefs.GetInt("ComingSoon");
    }

    public int SetComingSoon(int booleanNumber)
    {
        PlayerPrefs.SetInt("ComingSoon", booleanNumber);
        return GetComingSoon();
    }

    public void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
}
