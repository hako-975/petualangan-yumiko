using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VersionText : MonoBehaviour
{
    TextMeshProUGUI versionText;

    // Start is called before the first frame update
    void Start()
    {
        versionText = GetComponent<TextMeshProUGUI>();
        versionText.text = "Version " + Application.version;
    }
}
