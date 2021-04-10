using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLadderButtonPosition : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().localPosition = new Vector3(PlayerPrefsManager.instance.GetLadderButtonPositionX(), PlayerPrefsManager.instance.GetLadderButtonPositionY(), 0f);
    }
}
