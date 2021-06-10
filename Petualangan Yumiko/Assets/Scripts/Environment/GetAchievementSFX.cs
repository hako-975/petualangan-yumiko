using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAchievementSFX : MonoBehaviour
{
    public AudioSource achievementSFX;

    AchievementObject achievementObject;
    // Start is called before the first frame update
    void Start()
    {
        achievementSFX.playOnAwake = false;
        achievementObject = FindObjectOfType<AchievementObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (achievementObject.isPicked == true)
        {
            achievementSFX.Play();
            achievementObject.isPicked = false;
        }
    }
}
