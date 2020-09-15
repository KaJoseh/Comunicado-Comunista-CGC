using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetDamage : MonoBehaviour
{
    PlayerHealth playerH;
    public float damageAmount;

    // Start is called before the first frame update
    void Start()
    {
        playerH = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D bullet)
    {
        if (gameObject.tag.Equals("PlayerTwo") && bullet.gameObject.tag.Equals("P1Bullet") && playerH.health >= 0)
        {
            playerH.health -= damageAmount;
        }
        else if (gameObject.tag.Equals("PlayerOne") && bullet.gameObject.tag.Equals("P2Bullet") && playerH.health >= 0)
        {
            playerH.health -= damageAmount;
        }
    }
}
