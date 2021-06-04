using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefsManager.instance.DeleteKey("Timer"); 
        PlayerPrefs.DeleteKey("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefsManager.instance.DeleteKey("Timer");
        PlayerPrefs.DeleteKey("Timer");
    }
}
