using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BetterJumping))]
public class PlayerMovement : MonoBehaviour
{
    public KeyCode leftKey, rightKey, jumpKey;
    public float speed;
    public float jumpForce;
    Rigidbody2D rb;

    private bool canJump;
    private bool inAir;
    private bool onWall;    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk(leftKey, rightKey);
        if (Input.GetKey(jumpKey) && canJump)
            Jump();
    }

    #region Walk&Jump functions

    private void Walk(KeyCode left, KeyCode right)
    {
        if (Input.GetKey(left))
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        else if (Input.GetKey(right))
            rb.velocity = new Vector2(speed, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
    }

    private void Jump() 
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpForce;
        inAir = true;
        canJump = false;
    }

    #endregion

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag.Equals("Floor") && !canJump)
        {
            inAir = false;
            canJump = true;
        }
    }
}
