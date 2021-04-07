using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioClip newAudio;
    MusicManager musicManager;

    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        musicManager.GetComponent<AudioSource>().clip = newAudio;
        musicManager.GetComponent<AudioSource>().Play();
    }
}
