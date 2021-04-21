using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDamageBoss : MonoBehaviour
{
    public GameObject redButton;

    public GameObject ground;

    Collider colliderTrigger;

    BossController bossController;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(ground.transform.position.x - 4f, ground.transform.position.x + 4f), ground.transform.position.y, Random.Range(ground.transform.position.z - 4f, ground.transform.position.z + 4f));
        colliderTrigger = GetComponent<Collider>();
        bossController = FindObjectOfType<BossController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bossController.TakeDamage(1);
            redButton.transform.position = transform.position;
            colliderTrigger.isTrigger = false;
            colliderTrigger.enabled = false;
        }
    }
}
