using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    PlayerController player;
    public AudioSource audioRun;
    public AudioSource audioJump;
    public AudioSource audioFall;
    public AudioSource audioDied;
    public AudioSource audioGetHit;

    bool beingHandled = false;
    
    public float delaySoundRun = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded == true && player.move.magnitude >= 0.1f && audioRun.isPlaying == false && player.isClimbing == false)
        {
            audioRun.volume = Random.Range(0.8f, 1f);
            // audio.pitch = Random.Range(0.8f, 1.1f);
            if (!beingHandled)
            {
                StartCoroutine(DelaySoundRun(delaySoundRun));
            }
        }
    }

    IEnumerator DelaySoundRun(float delay)
    {
        beingHandled = true;
        yield return new WaitForSeconds(delay);
        audioRun.Play();
        beingHandled = false;
    }
}
