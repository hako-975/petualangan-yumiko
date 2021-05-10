using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecovery : MonoBehaviour
{
    AudioSource audioHealth;
    
    protected int currentHealth;

    bool isPicked = false;

    private void Start()
    {
        audioHealth = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // get current life
        currentHealth = PlayerPrefsManager.instance.GetHealth();

        // for rotate
        transform.Rotate(Vector3.up * 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (currentHealth < 4)
            {
                if (isPicked == false)
                {
                    audioHealth.Play();
                    audioHealth.volume = Random.Range(0.8f, 1f);
                    audioHealth.pitch = Random.Range(0.8f, 1f);

                    // destroy game object
                    Destroy(gameObject, audioHealth.clip.length);

                    // set life = get current life + 1
                    currentHealth += 1;
                    PlayerPrefsManager.instance.SetHealth(currentHealth);
                    
                    isPicked = true;
                }
            }
        }
    }
}
