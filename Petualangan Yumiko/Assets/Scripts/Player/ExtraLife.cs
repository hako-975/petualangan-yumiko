using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraLife : MonoBehaviour
{
    public int extraLifeTo;

    public AudioClip audioClip;

    int level;

    bool isPicked = false;

    GameObject sfx;

    private void Start()
    {
        sfx = GameObject.FindGameObjectWithTag("SFX");

        level = SceneManager.GetActiveScene().buildIndex;
        
        if (PlayerPrefsManager.instance.GetExtraLifeToBoolean(extraLifeTo, level) > 0)
        {
            gameObject.SetActive(false);
        }
    }

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
            if (isPicked == false)
            {
                // destroy game object
                Destroy(gameObject);

                sfx.GetComponent<AudioSource>().clip = audioClip;
                sfx.GetComponent<AudioSource>().Play();
                sfx.GetComponent<AudioSource>().volume = Random.Range(0.8f, 1f);
                sfx.GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1f);

                PlayerPrefsManager.instance.SetExtraLifeToBoolean(extraLifeTo, level);
                
                
                // get current life
                int currentLife = PlayerPrefsManager.instance.GetLife();

                // set life = get current life + 1
                currentLife += 1;
                PlayerPrefsManager.instance.SetLife(currentLife);
                isPicked = true;
            }
        }
    }
}
