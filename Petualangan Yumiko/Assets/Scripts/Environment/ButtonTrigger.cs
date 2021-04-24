using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject triggeredObject;
    public GameObject redButton;
    public Vector3 newPositionTriggerObject;

    AudioSource audioButton;

    Collider colliderTrigger;

    private void Start()
    {
        colliderTrigger = GetComponent<Collider>();
        audioButton = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioButton.Play();
            triggeredObject.transform.position = newPositionTriggerObject;
            redButton.transform.position = transform.position;
            colliderTrigger.isTrigger = false;
            colliderTrigger.enabled = false;
        }
    }
}
