using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    #region Singleton
    public static PlayerPrefsManager instance;
    
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public int GetLevelAt()
    {
        return PlayerPrefs.GetInt("levelAt");
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

    public int GetQuality()
    {
        return PlayerPrefs.GetInt("QualityIndex");
    }

    public int SetQuality(int qualityIndex)
    {
        PlayerPrefs.SetInt("QualityIndex", qualityIndex);
        return GetQuality();
    }

    public void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
}
