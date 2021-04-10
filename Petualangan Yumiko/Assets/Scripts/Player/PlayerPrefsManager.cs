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


    public float GetButtonSize()
    {
        return PlayerPrefs.GetFloat("ButtonSize", 200f);
    }

    public float SetButtonSize(float size)
    {
        PlayerPrefs.SetFloat("ButtonSize", size);
        return GetButtonSize();
    }

    public float GetLadderButtonPositionX()
    {
        return PlayerPrefs.GetFloat("LadderButtonPositionX", 550f);
    }

    public float SetLadderButtonPositionX(float posX)
    {
        PlayerPrefs.SetFloat("LadderButtonPositionX", posX);
        return GetLadderButtonPositionX();
    }

    public float GetLadderButtonPositionY()
    {
        return PlayerPrefs.GetFloat("LadderButtonPositionY", -250f);
    }

    public float SetLadderButtonPositionY(float posY)
    {
        PlayerPrefs.SetFloat("LadderButtonPositionY", posY);
        return GetLadderButtonPositionY();
    }

    public float GetJumpButtonPositionX()
    {
        return PlayerPrefs.GetFloat("JumpButtonPositionX", -100f);
    }

    public float SetJumpButtonPositionX(float posX)
    {
        PlayerPrefs.SetFloat("JumpButtonPositionX", posX);
        return GetJumpButtonPositionX();
    }

    public float GetJumpButtonPositionY()
    {
        return PlayerPrefs.GetFloat("JumpButtonPositionY", 100f);
    }

    public float SetJumpButtonPositionY(float posY)
    {
        PlayerPrefs.SetFloat("JumpButtonPositionY", posY);
        return GetJumpButtonPositionY();
    }


    public int GetCurrentHealth()
    {
        return PlayerPrefs.GetInt("CurrentHealth");
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
