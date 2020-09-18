using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    
    [Range(0.0f, 1.0f)]
    public float healthBarYPos;
    public TextMeshProUGUI ammoText;

    SetWinner setWinner;
    GameManager gm;
    GameStats gameStats;
    RoundManager roundM;

    bool canSetWinner;
    public float currentHealth;

    private void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        roundM = GameObject.FindWithTag("GameController").GetComponent<RoundManager>();
        setWinner = GameObject.FindWithTag("GameController").GetComponent<SetWinner>();
        gameStats = GameObject.FindWithTag("StatsController").GetComponent<GameStats>();

        currentHealth = gameStats.maxHealth;
        canSetWinner = true;
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.SetText(currentHealth.ToString());
        ammoText.transform.position = new Vector2(transform.position.x, transform.position.y + healthBarYPos);

        if(currentHealth < 0 && canSetWinner)
        {
            canSetWinner = false;
            gm.GameMode = GameManager.gameModes.ROUNDOVER;
            setWinner.SetRoundWinner();
            StartCoroutine(WaitForNewRound());
            
        }
    }


    private void OnTriggerEnter2D(Collider2D bullet)
    {
        if (gameObject.tag.Equals("PlayerTwo") && bullet.gameObject.tag.Equals("P1Bullet") && currentHealth >= 0)
        {
            currentHealth -= gameStats.damage;
            Destroy(bullet.gameObject);
        }
        else if (gameObject.tag.Equals("PlayerOne") && bullet.gameObject.tag.Equals("P2Bullet") && currentHealth >= 0)
        {
            currentHealth -= gameStats.damage;
            Destroy(bullet.gameObject);
        }
    }

    IEnumerator WaitForNewRound()
    {
        yield return new WaitForSeconds(2.0f);
        print("3.. 2... 1... YA!");
        roundM.NewRound();
        gm.GameMode = GameManager.gameModes.PLAYING;
        canSetWinner = true;
    }
}
