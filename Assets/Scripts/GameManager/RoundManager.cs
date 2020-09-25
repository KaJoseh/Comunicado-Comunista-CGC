using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundManager : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;

    GameManager gm;
    SetWinner setWinner;

    [Space]

    public GameObject p1Spawn;
    public GameObject p2Spawn;
    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
        setWinner = GetComponent<SetWinner>();
    }


    /// <summary>
    /// Reset the round when someone wins
    /// </summary>
    public void NewRound()
    {
        //setting players health
        p1.GetComponent<PlayerHealth>().currentHealth = gm.maxHealth;
        p2.GetComponent<PlayerHealth>().currentHealth = gm.maxHealth;

        //setting players position
        p1.transform.position = p1Spawn.transform.position;
        p2.transform.position = p2Spawn.transform.position;

        setWinner.victoryText.enabled = false;
    }
}
