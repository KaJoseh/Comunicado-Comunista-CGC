using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
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

        if (Input.GetKeyDown(shootKey) && playerH.bullets >= 0)
        {
            Shoot();
            playerH.bullets--;
        }
    }

    void Shoot()
    {
        GameObject firedBullet = Instantiate(bullet, cannon.gameObject.transform.position, cannon.gameObject.transform.rotation);

        if (gameObject.tag.Equals("PlayerOne"))
            firedBullet.GetComponent<SpriteRenderer>().color = Color.green;
        else
            firedBullet.GetComponent<SpriteRenderer>().color = Color.blue;

        firedBullet.GetComponent<Rigidbody2D>().velocity = cannon.gameObject.transform.up * bulletSpeed;
    }
}
