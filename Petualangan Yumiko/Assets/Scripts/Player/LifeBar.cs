using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeBar : MonoBehaviour
{
    public TextMeshProUGUI textLife;

    public void SetTextLife(int life)
    {
        textLife.text = life.ToString();
    }    
}
