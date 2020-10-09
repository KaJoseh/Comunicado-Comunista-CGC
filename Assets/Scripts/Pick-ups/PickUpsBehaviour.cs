using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsBehaviour : MonoBehaviour
{
    float healthBoost;

    // Start is called before the first frame update
    void Start()
    {
        healthBoost = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
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
