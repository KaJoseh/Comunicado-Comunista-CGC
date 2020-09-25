using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SetWinner : MonoBehaviour
{
    float p1CurrentHealth, p2CurrentHealth;
    public TextMeshProUGUI victoryText;

    GameManager gm;
    Timer timer;


    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
        timer = GameObject.FindWithTag("GameController").GetComponent<Timer>();
        victoryText.enabled = false;
    }
        

    /// <summary>
    /// Check who won and add they a point 
    /// </summary>
    /// <param name="score"></param>
    public void SetRoundWinner()
    {
        print("HOLA");
        p1CurrentHealth = GameObject.FindWithTag("PlayerOne").GetComponent<PlayerHealth>().currentHealth;
        p2CurrentHealth = GameObject.FindWithTag("PlayerTwo").GetComponent<PlayerHealth>().currentHealth;

        victoryText.enabled = true;

        //evaluate the winner
        if(p1CurrentHealth < 0 || p2CurrentHealth < 0)
        {
            if (p1CurrentHealth < 0 && p2CurrentHealth >= 0)
            {
                gm.p2Score++;
                victoryText.SetText("PLAYER TWO WINS!");

                print("PLAYER ONE: " + gm.p1Score + " PLAYER TWO: " + gm.p2Score);
            }
            //P1 Wins
            else if (p2CurrentHealth < 0 && p1CurrentHealth >= 0)
            {
                gm.p1Score++;
                victoryText.SetText("PLAYER ONE WINS!");

                print("PLAYER ONE: " + gm.p1Score + " PLAYER TWO: " + gm.p2Score);
            }
        }
        else if (p1CurrentHealth == p2CurrentHealth)
        {
            victoryText.SetText("TIE, FOOLS!");
        }
        else
        {
            if(p2CurrentHealth > p1CurrentHealth)
            {
                gm.p2Score++;
                victoryText.SetText("PLAYER TWO WINS!");

                print("PLAYER ONE: " + gm.p1Score + " PLAYER TWO: " + gm.p2Score);
            }
            else
            {
                gm.p1Score++;
                victoryText.SetText("PLAYER ONE WINS!");

                print("PLAYER ONE: " + gm.p1Score + " PLAYER TWO: " + gm.p2Score);
            }
        }

    }

    public void LookForGameWinner()
    {
        if (gm.p1Score >= 3)
        {
            gm.p1Score = 0;
            gm.p2Score = 0;
            SceneManager.LoadScene("SampleScene");
        }
        else if (gm.p2Score >= 3)
        {
            gm.p1Score = 0;
            gm.p2Score = 0;
            SceneManager.LoadScene("SampleScene");
        }
        else
            return;
    }

}
