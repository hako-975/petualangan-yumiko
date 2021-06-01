using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownManager : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public GameObject countdownTextPanel;

    private float countdownTime = 4;
    

    // Start is called before the first frame update
    void Start()
    {
        countdownTextPanel.gameObject.SetActive(true);
    }

    void Update()
    {
        if (countdownTime > 1)
        {
            countdownTime -= Time.deltaTime;
            countdownText.text = countdownTime.ToString("0");
        }
        else
        {
            countdownTextPanel.gameObject.SetActive(false);
        }
    }
}
