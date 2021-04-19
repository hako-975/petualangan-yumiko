using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraLife : MonoBehaviour
{
    public int extraLifeTo;

    // Update is called once per frame
    void Update()
    {
        // for rotate
        transform.Rotate(Vector3.up * 2f);
    
        if (PlayerPrefsManager.instance.GetExtraLifeToBoolean(extraLifeTo) > 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefsManager.instance.SetExtraLifeToBoolean(extraLifeTo);

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
