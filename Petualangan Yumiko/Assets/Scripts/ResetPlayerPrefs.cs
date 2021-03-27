using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Level At " + PlayerPrefsManager.instance.GetLevelAt());
    }
}
