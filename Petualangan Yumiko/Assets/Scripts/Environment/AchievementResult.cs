using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementResult : MonoBehaviour
{
    public GameObject table;
    public GameObject[] achievementObject;
    
    int i = 0;
    float posZ = 0;
    bool newPosZ = false;
    bool newPosZ_2 = false;
    bool newPosZ_3 = false;
    bool newPosZ_4 = false;
    // Update is called once per frame
    void Update()
    {

        for (; i < achievementObject.Length; i++)
        {
            if (i < 5)
            {
                Instantiate(table, new Vector3(2.5f, 0.68f, posZ), Quaternion.identity);
                if (PlayerPrefsManager.instance.GetBoolAchievementObject(i + 1) > 0)
                {
                    Instantiate(achievementObject[i], new Vector3(2.5f, 0.915f, posZ), Quaternion.identity);
                }
                posZ -= 1.85f;
            }
            else if (i < 10)
            {
                if (newPosZ == false)
                {
                    posZ = 0f;
                    newPosZ = true;
                }

                Instantiate(table, new Vector3(4f, 0.68f, posZ), Quaternion.identity);
                if (PlayerPrefsManager.instance.GetBoolAchievementObject(i + 1) > 0)
                {
                    Instantiate(achievementObject[i], new Vector3(4f, 0.915f, posZ), Quaternion.identity);
                }
                posZ -= 1.85f;
            }
            else if (i < 15)
            {
                if (newPosZ_2 == false)
                {
                    posZ = 0f;
                    newPosZ_2 = true;
                }

                Instantiate(table, new Vector3(5.5f, 0.68f, posZ), Quaternion.identity);
                if (PlayerPrefsManager.instance.GetBoolAchievementObject(i + 1) > 0)
                {
                    Instantiate(achievementObject[i], new Vector3(5.5f, 0.915f, posZ), Quaternion.identity);
                }

                posZ -= 1.85f;
            }
            else if (i < 20)
            {
                if (newPosZ_3 == false)
                {
                    posZ = 0f;
                    newPosZ_3 = true;
                }

                Instantiate(table, new Vector3(7f, 0.68f, posZ), Quaternion.identity);
                if (PlayerPrefsManager.instance.GetBoolAchievementObject(i + 1) > 0)
                {
                    Instantiate(achievementObject[i], new Vector3(7f, 0.915f, posZ), Quaternion.identity);
                }

                posZ -= 1.85f;
            }
            else if (i < 25)
            {
                if (newPosZ_4 == false)
                {
                    posZ = 0f;
                    newPosZ_4 = true;
                }

                Instantiate(table, new Vector3(8.5f, 0.68f, posZ), Quaternion.identity);
                if (PlayerPrefsManager.instance.GetBoolAchievementObject(i + 1) > 0)
                {
                    Instantiate(achievementObject[i], new Vector3(8.5f, 0.915f, posZ), Quaternion.identity);
                }

                posZ -= 1.85f;
            }
        }
    }
}
