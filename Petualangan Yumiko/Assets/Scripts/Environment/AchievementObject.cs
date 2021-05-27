using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementObject : MonoBehaviour
{
    public GameObject achievementImage;
    public Sprite ImageIcon;

    AudioSource audioGetAchievement;
    bool isPicked = false;

    void Start()
    {
        achievementImage.GetComponent<Image>().sprite = ImageIcon;
        achievementImage.gameObject.SetActive(false);
        audioGetAchievement = GetComponent<AudioSource>();
        audioGetAchievement.playOnAwake = false;
    }

    private void Update()
    {
        if (PlayerPrefsManager.instance.GetBoolAchievementTemp() > 0)
        {
            Destroy(gameObject);
            achievementImage.gameObject.SetActive(true);
            isPicked = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isPicked == false)
            {
                audioGetAchievement.Play();
                Destroy(gameObject, audioGetAchievement.clip.length);
                PlayerPrefsManager.instance.SetBoolAchievementTemp(1);
                achievementImage.gameObject.SetActive(true);
                isPicked = true;
            }
        }
    }
}
