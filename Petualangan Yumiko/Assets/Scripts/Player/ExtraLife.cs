using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // for rotate
        transform.Rotate(Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // destroy game object
            this.gameObject.SetActive(false);

            // get current life
            int currentLife = PlayerPrefsManager.instance.GetLife();

            // set life = get current life + 1
            currentLife += 1;
            PlayerPrefsManager.instance.SetLife(currentLife);
        }
    }
}
