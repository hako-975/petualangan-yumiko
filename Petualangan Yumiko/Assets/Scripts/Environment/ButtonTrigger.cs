using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject triggeredObject;
    public GameObject redButton;
    public Vector3 newPositionTriggerObject;
    public Vector3 newPositionRedButton;

    Collider colliderTrigger;

    private void Start()
    {
        colliderTrigger = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggeredObject.transform.position = newPositionTriggerObject;
            redButton.transform.position = newPositionRedButton;
            colliderTrigger.isTrigger = false;
            colliderTrigger.enabled = false;
        }
    }
}
