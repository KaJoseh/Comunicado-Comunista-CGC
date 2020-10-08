﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerGetDamage))]
public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float bulletSpeed;
    [SerializeField]
    GameObject cannon;
    [SerializeField]
    GameObject target;
    [SerializeField]
    KeyCode shootKey;


    Vector2 direction;
    PlayerHealth playerH;

    // Start is called before the first frame update
    void Start()
    {
        playerH = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
        cannon.transform.up = direction;

        if (Input.GetKeyDown(shootKey) && playerH.currentHealth >= 0)
        {
            Shoot();
            playerH.currentHealth--;
        }
    }

    void Shoot()
    {
        GameObject firedBullet = Instantiate(bullet, cannon.gameObject.transform.position, cannon.gameObject.transform.rotation);

        if (gameObject.tag.Equals("PlayerOne"))
        {
            firedBullet.GetComponent<SpriteRenderer>().color = Color.green;
            firedBullet.gameObject.tag = "P1Bullet";
        }
        else
        {
            firedBullet.GetComponent<SpriteRenderer>().color = Color.blue;
            firedBullet.gameObject.tag = "P2Bullet";
        }

        firedBullet.GetComponent<Rigidbody2D>().velocity = cannon.gameObject.transform.up * bulletSpeed;
    }
}
