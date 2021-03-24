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
}
