using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetWinner : MonoBehaviour
{
    float p1Health, p2Health;
    public TextMeshProUGUI victoryText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        p1Health = GameObject.FindWithTag("PlayerOne").GetComponent<PlayerHealth>().health;
        p2Health = GameObject.FindWithTag("PlayerTwo").GetComponent<PlayerHealth>().health;

        //if a player's health = 0
        if (p1Health < 0 || p2Health < 0)
        {
            victoryText.enabled = true;

            if (p1Health < 0 && p2Health >= 0)
            {
                victoryText.SetText("PLAYER TWO WINS!");
            }
            else if (p2Health < 0 && p1Health >= 0)
            {
                victoryText.SetText("PLAYER ONE WINS!");
            }
        }
        else
            victoryText.enabled = false;
    }
}
