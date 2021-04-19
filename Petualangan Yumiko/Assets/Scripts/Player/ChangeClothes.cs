using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeClothes : MonoBehaviour
{
    public GameObject clothes1;
    public GameObject clothes2;
    public GameObject healthBar;
    bool triggered = false;
    PlayerController player;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        healthBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetAxisRaw("Horizontal") + player.joystick.Horizontal < 0f) && (Input.GetKey(KeyCode.Space) || player.jumpButton.pressed))
        {
            triggered = true;
        }

        if ((Input.GetAxisRaw("Vertical") + player.joystick.Vertical > 0f) && (Input.GetKey(KeyCode.Space) || player.jumpButton.pressed))
        {
            clothes1.gameObject.SetActive(true);
            clothes2.gameObject.SetActive(false);
        }

        if (triggered)
        {
            if ((Input.GetAxisRaw("Horizontal") + player.joystick.Horizontal > 0f) && (Input.GetKey(KeyCode.Space) || player.jumpButton.pressed))
            {
                clothes1.gameObject.SetActive(false);
                clothes2.gameObject.SetActive(true);
                triggered = false;
            }
        }
    }
}
