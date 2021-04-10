using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetJumpButtonPosition : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerPrefsManager.instance.GetJumpButtonPositionX(), PlayerPrefsManager.instance.GetJumpButtonPositionY(), 0f);
    }
}
