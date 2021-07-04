using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timer;

    [HideInInspector]
    public float t;

    private float startTime;

    [HideInInspector]
    public bool finished = false;

    protected string minutes;
    protected string seconds;
    protected string milliseconds;

    private void Start()
    {

        if (PlayerPrefsManager.instance.GetTimer() > 0)
        {
            startTime = Time.time - PlayerPrefsManager.instance.GetTimer();
        }
        else
        {
            startTime = Time.time;
        }
    }

    private void Update()
    {
        if (finished == false)
        {

            t = Time.time - startTime;
            minutes = ((int)t / 60).ToString("00");
            seconds = (t % 60).ToString("00");
            milliseconds = (t % 60).ToString();

            milliseconds = milliseconds.Substring(3, 2);

            timer.text = minutes + ":" + seconds + ":" + milliseconds;
            PlayerPrefsManager.instance.SetTimer(t);
        }
    }

    public void Finish()
    {
        int levelAt = SceneManager.GetActiveScene().buildIndex;

        PlayerPrefsManager.instance.SetTimerText(levelAt, minutes + ":" + seconds + ":" + milliseconds);
        finished = true;
        timer.color = Color.yellow;
    }
}
