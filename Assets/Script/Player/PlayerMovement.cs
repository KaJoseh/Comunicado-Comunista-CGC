using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BetterJumping))]
[RequireComponent(typeof(MovementCollisions))]
public class PlayerMovement : MonoBehaviour
{

    public KeyCode leftKey, rightKey, jumpKey, downKey, dashKey;

    [Space]
    [Header("Movement vars")]
    public float speed;
    public float jumpForce;

    [Space]
    [Header("Dash vars")]
    public float dashForce;
    public float dashTime;
    public float dashColdown;

    [Space]

    [Header("Time to fall from a wall")]
    public float fallWallCounter;

    private float wallCounter;
    private float dashCounter;
    private int xDir;
    private Rigidbody2D rb;
    private MovementCollisions mColl;
    private bool wallJumping;
    //private bool dashing;
    //private bool canDash = true;


    // Start is called before the first frame update
    void Start()
    {
        wallCounter = fallWallCounter;
        //dashCounter = dashTime;
        rb = gameObject.GetComponent<Rigidbody2D>();
        mColl = GetComponent<MovementCollisions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(rightKey))
            xDir = 1;
        else if (Input.GetKey(leftKey))
            xDir = -1;

        //print(canDash);

        if ((!mColl.onWall || mColl.onGround) && !wallJumping) { }
            Walk();

        if (Input.GetKey(jumpKey) && mColl.onGround)
            Jump();

        if((!mColl.onWall && !mColl.onGround) || mColl.onGround)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            wallCounter = fallWallCounter;

            /*
            if (Input.GetKey(dashKey) && canDash)
            {
                Dash();
            }
            */
        }

        #region WallJumping Conditions

        if (mColl.onWall && !mColl.onGround)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            if (wallCounter <= 0)
            {
                if (mColl.onWall && mColl.onRightWall)
                {
                    JumpingFromWall();
                    rb.velocity = Vector2.Lerp(new Vector2 (rb.velocity.x, rb.velocity.y), new Vector2(-speed * 4, rb.velocity.y), 2);
                }
                else if (mColl.onWall && mColl.onLeftWall)
                {
                    JumpingFromWall();
                    rb.velocity = Vector2.Lerp(new Vector2(rb.velocity.x, rb.velocity.y), new Vector2(speed * 4, rb.velocity.y),2);
                    //rb.velocity = new Vector2(speed * 4, rb.velocity.y);
                }
            }
            else if (wallCounter >= 0)
                wallCounter -= Time.deltaTime;


            if (Input.GetKey(jumpKey))
            {
                WallJump();
            }
            else if (Input.GetKey(rightKey) && !mColl.onRightWall)
            {
                WallJump();
            }
            else if (Input.GetKey(leftKey) && mColl.onRightWall)
            {
                WallJump();
            }
        }

        #endregion
    }



    #region Walk&Jump functions

    private void Walk()
    {
        if(Input.GetKey(leftKey) || Input.GetKey(rightKey))
            rb.velocity = new Vector2(xDir * speed, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
    }

    private void Jump() 
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpForce;
    }

    private void WallJump()
    {
        JumpingFromWall();
        rb.velocity = new Vector2(rb.velocity.x, 0);
        if (mColl.onRightWall)
        {
            rb.velocity = new Vector2(-speed * 2, jumpForce);
        }
        else if (mColl.onLeftWall)
        {
            rb.velocity = new Vector2(speed * 2, jumpForce);
        }
    }

    void JumpingFromWall()
    {   
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        wallJumping = true;
        StartCoroutine(SetWalljumpingFalse());
    }

    #endregion

    void Dash()
    {
        /*
        if (dashCounter > 0)
        {
            rb.velocity = new Vector2(0, 0);
            if (Input.GetKey(leftKey) || Input.GetKey(rightKey))
                rb.velocity += new Vector2(xDir * speed * dashForce, rb.velocity.y);

            if (Input.GetKey(jumpKey))
                rb.velocity += new Vector2(rb.velocity.x, jumpForce * dashForce);
            else if (Input.GetKey(downKey))
                rb.velocity += new Vector2(rb.velocity.x, -jumpForce * dashForce);

            dashCounter -= Time.deltaTime;
        }
        else if (dashCounter <= 0)
        {
            StartCoroutine(WaitForNextDash());
        }
        */
    }

    IEnumerator SetWalljumpingFalse()
    {
        yield return new WaitForSeconds(0.09f);
        wallJumping = false;
    }

    /*
    IEnumerator WaitForNextDash()
    {
        canDash = false;
        yield return new WaitForSeconds(dashColdown);
        canDash = true;
    }
    */
}
