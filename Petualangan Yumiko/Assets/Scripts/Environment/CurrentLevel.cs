using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CurrentLevel : MonoBehaviour
{
    int currentLevel;
    TextMeshProUGUI textLevel;
    
    private void Update()
    {
        textLevel = GetComponent<TextMeshProUGUI>();

        // check current scene - 3 karena build index level 4 adalah 7
        currentLevel = SceneManager.GetActiveScene().buildIndex - 3;
        textLevel.text = "Level " + currentLevel.ToString();
    }
}
