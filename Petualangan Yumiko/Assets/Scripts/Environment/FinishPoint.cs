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
            if (nextSceneLoad > PlayerManager.instance.GetLevelAt())
            {
                // jika level sebelumnya tidak lebih dari scene yang sudah pernah, simpan data level baru
                PlayerManager.instance.SetLevelAt(nextSceneLoad);
            }

            SceneManager.LoadScene(nextSceneLoad);
        }
    }
}
