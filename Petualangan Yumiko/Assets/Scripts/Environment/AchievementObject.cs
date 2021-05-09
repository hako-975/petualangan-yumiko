using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementObject : MonoBehaviour
{
    public GameObject setActiveAchievement;
    public Sprite ImageIcon;

    void Start()
    {
        setActiveAchievement.GetComponent<Image>().sprite = ImageIcon;
        setActiveAchievement.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerPrefsManager.instance.SetBoolAchievementTemp(1);
            setActiveAchievement.gameObject.SetActive(true);
        }
    }
}
