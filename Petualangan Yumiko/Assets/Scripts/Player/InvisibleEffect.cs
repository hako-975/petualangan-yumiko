using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleEffect : MonoBehaviour
{
    SkinnedMeshRenderer body;
    bool beingHandled = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.instance.isDied || PlayerStats.instance.animator.GetBool("IsHit") == true)
        {
            body.enabled = true;
        }

        if (!beingHandled)
        {
            StartCoroutine(DelayInvisible(0.1f));
        }

        if (PlayerStats.instance.isInvisible && PlayerStats.instance.isDied == false)
        {
            body.enabled = false;
        }
       
    }
    IEnumerator DelayInvisible(float delay)
    {
        beingHandled = true;
        yield return new WaitForSeconds(delay);
        body.enabled = true;
        beingHandled = false;
    }
}
