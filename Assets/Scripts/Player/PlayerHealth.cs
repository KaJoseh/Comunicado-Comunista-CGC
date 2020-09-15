using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public TextMeshProUGUI bulletText;

    // Update is called once per frame
    void Update()
    {
        bulletText.SetText(health.ToString());

        if(health < 0)
        {
            //print("MUERTO");
        }
    }
}
