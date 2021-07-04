using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerBoard : MonoBehaviour
{
    public TextMeshPro[] textLevel;

    void Update()
    {
        for (int i = 1; i < textLevel.Length; i++)
        {
            textLevel[i].text = "Level " + i + " = " + PlayerPrefsManager.instance.GetTimerText(i);
        }        
    }
}
