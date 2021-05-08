using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrackObject : MonoBehaviour
{
    public float waitDrop = 2f;
    public float waitBack = 3f;
    Vector3 currentPos;
    public float newPosY;

    bool isHandledExit = false;
    bool isHandledEnter = false;

    private void Start()
    {
        currentPos = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isHandledEnter == false)
            {
                StartCoroutine(DropObject());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isHandledExit == false)
        {
            StartCoroutine(BackObject());
        }
    }

    IEnumerator DropObject()
    {
        isHandledEnter = true;
        yield return new WaitForSeconds(waitDrop);
        gameObject.transform.position = new Vector3(transform.position.x, newPosY, transform.position.z);
        isHandledEnter = false;
    }

    IEnumerator BackObject()
    {
        isHandledExit = true;
        yield return new WaitForSeconds(waitBack);
        gameObject.transform.position = currentPos;
        isHandledExit = false;
    }
}
