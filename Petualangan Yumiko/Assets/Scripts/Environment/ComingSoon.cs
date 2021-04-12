using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingSoon : MonoBehaviour
{ 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefsManager.instance.SetComingSoon(1);
            PlayerPrefsManager.instance.SetNextScene("Coming Soon");
        }
    }
}
