using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecovery : MonoBehaviour
{
    protected int currentHealth;

    bool isPicked = false;
    
    GameObject sfx;

    public AudioClip audioClip;

    private void Start()
    {
        sfx = GameObject.FindGameObjectWithTag("SFX");
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
                    // destroy game object
                    Destroy(gameObject);

                    sfx.GetComponent<AudioSource>().clip = audioClip; 
                    sfx.GetComponent<AudioSource>().Play();
                    sfx.GetComponent<AudioSource>().volume = Random.Range(0.8f, 1f);
                    sfx.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1f);

                    

                    // set life = get current life + 1
                    currentHealth += 1;
                    PlayerPrefsManager.instance.SetHealth(currentHealth);
                    
                    isPicked = true;
                }
            }
        }
    }
}
