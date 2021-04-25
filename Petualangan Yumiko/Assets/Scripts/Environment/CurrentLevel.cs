using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CurrentLevel : MonoBehaviour
{
    TextMeshProUGUI textLevel;
    
    private void Update()
    {
        textLevel = GetComponent<TextMeshProUGUI>();

        textLevel.text = SceneManager.GetActiveScene().name;
    }
}
