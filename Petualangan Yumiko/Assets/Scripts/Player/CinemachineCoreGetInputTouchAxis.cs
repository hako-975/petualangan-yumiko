using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCoreGetInputTouchAxis : MonoBehaviour
{
    public float TouchSensitivity_x = 10f;
    public float TouchSensitivity_y = 10f;
    public TouchField touchField;

    // Use this for initialization
    void Start()
    {
        CinemachineCore.GetInputAxis = HandleAxisInputDelegate;
        touchField = FindObjectOfType<TouchField>();
    }

    float HandleAxisInputDelegate(string axisName)
    {
        switch (axisName)
        {

            case "Touch X":
                return touchField.TouchDist.x / TouchSensitivity_x;


            case "Touch Y":
                return touchField.TouchDist.y / TouchSensitivity_y;


            default:
                Debug.LogError("Input <" + axisName + "> not recognyzed.", this);
                break;
        }

        return 0f;
    }
}
