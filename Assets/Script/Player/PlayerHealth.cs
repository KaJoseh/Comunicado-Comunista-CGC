using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float bullets;
    public TextMeshProUGUI bulletText;

    // Update is called once per frame
    void Update()
    {
        bulletText.SetText(bullets.ToString());

        if(bullets < 0)
        {
            print("MUERTO");
        }
    }
}
