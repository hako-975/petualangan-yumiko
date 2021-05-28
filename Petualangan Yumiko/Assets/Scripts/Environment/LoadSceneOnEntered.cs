using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnEntered : MonoBehaviour
{
    public string nextSceneLoad;

    AudioSource audioEntered;

    bool isEntered = false;

    void Start()
    {
        audioEntered = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!isEntered)
        {
            audioEntered.pitch -= 0.01f;
        }
        else
        {
            audioEntered.pitch = 1f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEntered = true;
            audioEntered.Play();
            StartCoroutine(WaitDuration());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEntered = false;
        }
    }

    IEnumerator WaitDuration()
    {
        yield return new WaitForSeconds(audioEntered.clip.length);

        if (isEntered == true)
        {

            PlayerPrefsManager.instance.SetCurrentLevel(0);

            PlayerPrefsManager.instance.SetNextScene(nextSceneLoad);
        }
    }
}
