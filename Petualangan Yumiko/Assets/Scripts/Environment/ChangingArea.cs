using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingArea : MonoBehaviour
{
    ChangeClothes changeClothes;
    public GameObject area;
    bool inArea = false;

    private void Start()
    {
        changeClothes = FindObjectOfType<ChangeClothes>();
    }

    private void Update()
    {
        if (inArea)
        {
            area.gameObject.SetActive(true);
        }
        else
        {
            area.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            changeClothes.GetComponent<ChangeClothes>().enabled = true;
            inArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            changeClothes.GetComponent<ChangeClothes>().enabled = false;
            inArea = false;
        }
    }
}
