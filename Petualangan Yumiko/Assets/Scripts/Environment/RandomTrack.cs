using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrack : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject prefabButton;
    public GameObject finishTrack;
    public float maxLengthTrack;

    BossController bossController;

    PlayerController player;
    
    public GameObject exitBoss;

    public GameObject dangerZone;

    float lastPositionZ = 15f;

    int random = 0;
    int i = 0;
    int j = 0;

    bool isFinish = false;

    bool objFinish = false;

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
        float lengthArea = player.transform.position.z;
        dangerZone.transform.position = new Vector3(dangerZone.transform.position.x, dangerZone.transform.position.y, lengthArea);

        if (lengthArea == 0)
        {
            lengthArea = 5f;
        }
        else
        {
            lengthArea -= 5f;
        }

        for (; i < lengthArea; i++)
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
            if (objFinish == false)
            {
                Instantiate(finishTrack, new Vector3(0f, -5f, lengthArea + 20f), Quaternion.identity);
                objFinish = true;
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
            }
        }
        
    }    
}

