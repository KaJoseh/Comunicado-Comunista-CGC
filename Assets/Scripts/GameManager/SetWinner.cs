using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetWinner : MonoBehaviour
{
    float p1Health, p2Health;
    public int p1Score, p2Score;

    public TextMeshProUGUI victoryText;


    // Start is called before the first frame update
    void Start()
    {
        victoryText.enabled = false;
    }
        

    /// <summary>
    /// Check who won and add they a point 
    /// </summary>
    /// <param name="score"></param>
    public void SetRoundWinner()
    {
        p1Health = GameObject.FindWithTag("PlayerOne").GetComponent<PlayerHealth>().currentHealth;
        p2Health = GameObject.FindWithTag("PlayerTwo").GetComponent<PlayerHealth>().currentHealth;

        victoryText.enabled = true;

        //evaluate the winner

        //P2 wins
        if (p1Health < 0 && p2Health >= 0)
        {
            p2Score++;
            victoryText.SetText("PLAYER TWO WINS!");

            print("PLAYER ONE: " + p1Score + " PLAYER TWO: " + p2Score);
        }
        //P1 Wins
        else if (p2Health < 0 && p1Health >= 0)
        {
            p1Score++;
            victoryText.SetText("PLAYER ONE WINS!");

            print("PLAYER ONE: " + p1Score + " PLAYER TWO: " + p2Score);
        }

    }

    void LookForGameWinner()
    {
        if(p1Score >= 3)
        {

        }
        else if (p2Score >= 3)
        {

        }
    }

}
