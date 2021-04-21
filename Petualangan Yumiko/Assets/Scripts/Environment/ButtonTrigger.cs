using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject triggeredObject;
    public GameObject redButton;
    public Vector3 newPositionTriggerObject;

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
            redButton.transform.position = transform.position;
            colliderTrigger.isTrigger = false;
            colliderTrigger.enabled = false;
        }
    }
}
