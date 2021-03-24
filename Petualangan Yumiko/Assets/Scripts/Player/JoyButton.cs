    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    [HideInInspector]
    public bool pressed;

    public Image buttonPressed;
    public Image button;

    void Start()
    {
        if (buttonPressed != null)
        {
            buttonPressed.enabled = false;
        }
    }    

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;

        if (buttonPressed != null)
        {
            buttonPressed.enabled = true;
        }

        if (button != null)
        {
            button.enabled = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;

        if (buttonPressed != null)
        {
            buttonPressed.enabled = false;
        }
        if (button != null)
        {
            button.enabled = true;
        }
    }
}
