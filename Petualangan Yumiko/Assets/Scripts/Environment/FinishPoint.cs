using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [HideInInspector]
    public int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                // jika level sebelumnya tidak lebih dari scene yang sudah pernah, simpan data level baru
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }

            SceneManager.LoadScene(nextSceneLoad);
        }
    }
}
