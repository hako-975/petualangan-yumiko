using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraLife : MonoBehaviour
{
    public int extraLifeTo;

    int level;

    AudioSource audioExtraLife;

    bool isPicked = false;

    private void Start()
    {
        audioExtraLife = GetComponent<AudioSource>();
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
                audioExtraLife.Play();

                audioExtraLife.volume = Random.Range(0.8f, 1f);
                audioExtraLife.pitch = Random.Range(0.8f, 1f);

                PlayerPrefsManager.instance.SetExtraLifeToBoolean(extraLifeTo, level);
                
                // destroy game object
                Destroy(gameObject, audioExtraLife.clip.length);

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
