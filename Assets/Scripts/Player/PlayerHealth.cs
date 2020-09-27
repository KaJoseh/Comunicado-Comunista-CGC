using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    
    [Range(0.0f, 1.0f)]
    public float healthBarYPos;
    public TextMeshProUGUI ammoText;

    Rigidbody2D rb;
    GameManager gm;


    bool canSetWinner;
    public float currentHealth;

    private void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentHealth = gm.maxHealth;
        canSetWinner = true;
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.SetText(currentHealth.ToString());
        ammoText.transform.position = new Vector2(transform.position.x, transform.position.y + healthBarYPos);

        if(currentHealth < 0)
        {
            //canSetWinner = false;
            gm.GameMode = GameManager.gameModes.ROUNDOVER;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D bullet)
    {
        if (gameObject.tag.Equals("PlayerTwo") && bullet.gameObject.tag.Equals("P1Bullet") && currentHealth >= 0)
        {
            currentHealth -= gm.damage;
            Destroy(bullet.gameObject);
            Knockback(bullet.gameObject);
        }
        else if (gameObject.tag.Equals("PlayerOne") && bullet.gameObject.tag.Equals("P2Bullet") && currentHealth >= 0)
        {
            currentHealth -= gm.damage;
            Destroy(bullet.gameObject);
            Knockback(bullet.gameObject);
        }
    }

    void Knockback(GameObject bullet)
    {
        Vector3 moveDirection = rb.transform.position - bullet.transform.position;
        rb.AddForce(moveDirection.normalized * 500f);
    }

}
