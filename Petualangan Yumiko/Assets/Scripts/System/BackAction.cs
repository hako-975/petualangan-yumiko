using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAction : MonoBehaviour
{
    public GameObject exitPanel;
    bool isShowing = false;

    // Update is called once per frame
    void Update()
    {
        if (isShowing == true)
        {
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isShowing = false;
            }
        }
        else
        {
            Time.timeScale = 1;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isShowing = true;
            }
        }

        exitPanel.gameObject.SetActive(isShowing);
    }

    public void BackButtonPressed()
    {
        isShowing = false;
    }

    public void QuitButtonPressed()
    {
        isShowing = true;
    }
}
