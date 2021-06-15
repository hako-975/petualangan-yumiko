using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrack : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject[] prefabsDecoration;
    public GameObject prefabButton;
    public GameObject finishTrack;
    public GameObject achievementObject;
    public float maxLengthTrack;
    public float percentBuildDiscount = 90f;

    BossController bossController;

    PlayerController player;
    
    public GameObject exitBoss;

    public GameObject dangerZone;

    float lastPositionZ = 15f;
    float lastPositionZDecoration = 15f;
    float lengthArea;

    int random = 0;
    int i = 0;
    int j = 0;

    int p = 0;

    bool isFinish = false;

    // Start is called before the first frame update
    void Start()
    {
        bossController = FindObjectOfType<BossController>();
        player = FindObjectOfType<PlayerController>();
        exitBoss.gameObject.SetActive(false);
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        lengthArea = player.transform.position.z;
        
        if (lengthArea == 0f)
        {
            lengthArea = 5f;
        }

        dangerZone.transform.position = new Vector3(dangerZone.transform.position.x, dangerZone.transform.position.y, lengthArea);

        for (; p < (lengthArea - (lengthArea * percentBuildDiscount / 100f)) / 6f; p++)
        {
            float randomPosZ = Random.Range(10f, 13f);

            int randomObjDecoration = Random.Range(0, prefabsDecoration.Length);
            float randomPosXDecoration = Random.Range(0, 10);

            if (randomPosXDecoration >= 0 && randomPosXDecoration <= 5)
            {
                randomPosXDecoration = -20f;
            }
            else if (randomPosXDecoration >= 6 && randomPosXDecoration <= 10)
            {
                randomPosXDecoration = 20f;
            }

            Instantiate(prefabsDecoration[randomObjDecoration], new Vector3(randomPosXDecoration, -5.5f, lastPositionZDecoration), Quaternion.identity);


            lastPositionZDecoration += randomPosZ + 60f;
        }

        for (; i < lengthArea - (lengthArea * percentBuildDiscount / 100f); i++)
        {
            int randomObj = Random.Range(0, prefabs.Length);
            float randomPosX = Random.Range(-5f, 5f);
            float randomPosY = Random.Range(-6f, -5f);
            float randomPosZ = Random.Range(10f, 13f);
            
            
            if (lengthArea > 5f)
            {
                random = Random.Range(0, 5);
            }

            Instantiate(prefabs[randomObj], new Vector3(randomPosX, randomPosY, lastPositionZ), Quaternion.identity);

            if (j <= 0)
            {
                if (random == 1 && !isFinish)
                {
                    Instantiate(prefabButton, new Vector3(randomPosX, randomPosY, lastPositionZ), Quaternion.identity);
                    j = 5;
                }
            }

            j--;

            lastPositionZ += randomPosZ;
        }


        if (lengthArea > maxLengthTrack)
        {
            if (isFinish == false)
            {
                Instantiate(finishTrack, new Vector3(0f, -5f, lengthArea + 20f), Quaternion.identity);
                Instantiate(achievementObject, new Vector3(0f, 0.75f, lengthArea + 50f), Quaternion.identity);
                isFinish = true;
            }
        }

        if (!isFinish)
        {
            if (bossController.isDied)
            {
                exitBoss.gameObject.SetActive(true);
                exitBoss.transform.position = player.transform.position;
                isFinish = true;
                Instantiate(finishTrack, new Vector3(0f, -5f, lengthArea + 20f), Quaternion.identity);
                Instantiate(achievementObject, new Vector3(0f, 0.75f, lengthArea + 50f), Quaternion.identity);
            }
        }
        
    }    
}

