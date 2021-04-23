using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecovery : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // for rotate
        transform.Rotate(Vector3.up * 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // get current life
            int currentHealth = PlayerPrefsManager.instance.GetHealth();

            if (currentHealth < 4)
            {
                // destroy game object
                this.gameObject.SetActive(false);

                // set life = get current life + 1
                currentHealth += 1;
                PlayerPrefsManager.instance.SetHealth(currentHealth);
            }
        }
    }
}
