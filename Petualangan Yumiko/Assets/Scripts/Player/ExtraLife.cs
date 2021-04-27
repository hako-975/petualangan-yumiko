using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraLife : MonoBehaviour
{
    public int extraLifeTo;

    int level;

    AudioSource audioExtraLife;

    private void Start()
    {
        audioExtraLife = GetComponent<AudioSource>();
        level = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        // for rotate
        transform.Rotate(Vector3.up * 2f);
    
        if (PlayerPrefsManager.instance.GetExtraLifeToBoolean(extraLifeTo, level) > 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioExtraLife.Play();
            audioExtraLife.volume = Random.Range(0.8f, 1f);

            PlayerPrefsManager.instance.SetExtraLifeToBoolean(extraLifeTo, level);
            // destroy game object
            gameObject.SetActive(false);

            // get current life
            int currentLife = PlayerPrefsManager.instance.GetLife();

            // set life = get current life + 1
            currentLife += 1;
            PlayerPrefsManager.instance.SetLife(currentLife);
        }
    }
}
