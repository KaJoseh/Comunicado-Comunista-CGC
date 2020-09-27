using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMissedBullet : MonoBehaviour
{

    float waitToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        waitToDestroy = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        waitToDestroy -= Time.deltaTime;
        if (waitToDestroy <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (!(c.gameObject.tag == "PlayerOne" || c.gameObject.tag == "PlayerTwo"))
        {
            Destroy(gameObject);
        }
    }
}
