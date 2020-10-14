using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsBehaviour : MonoBehaviour
{
    float rand;
    float healthBoost;

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(1, 10);
        if (rand <= 4)
        {
            healthBoost = 10;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if(rand <= 8)
        {
            healthBoost = 16;
            gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        } 
        else if(rand <= 10)
        {
            healthBoost = 22;
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }


    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag.Equals("PlayerOne") || c.gameObject.tag.Equals("PlayerTwo"))
        {
            Destroy(gameObject);
            c.gameObject.GetComponent<PlayerHealth>().currentHealth += healthBoost;
        }
    }

}
