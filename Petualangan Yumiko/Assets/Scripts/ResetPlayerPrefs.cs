using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }

}