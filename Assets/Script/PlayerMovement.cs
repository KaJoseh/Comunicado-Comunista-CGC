using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BetterJumping))]
[RequireComponent(typeof(MovementCollisions))]
public class PlayerMovement : MonoBehaviour
{

    public KeyCode leftKey, rightKey, jumpKey;

    [Space]

    public float speed;
    public float jumpForce;
    [Header("Time to fall from a wall")]
    public float fallWallCounter;
    private float counter;

    private Rigidbody2D rb;
    private MovementCollisions mColl;
    private bool wallJumping;

   
    // Start is called before the first frame update
    void Start()
    {
        counter = fallWallCounter;
        rb = gameObject.GetComponent<Rigidbody2D>();
        mColl = GetComponent<MovementCollisions>();
    }

    // Update is called once per frame
    void Update()
    {
        if((!mColl.onWall || mColl.onGround) && !wallJumping)
            Walk(leftKey, rightKey);
        if (Input.GetKey(jumpKey) && mColl.onGround)
            Jump();

        if((!mColl.onWall && !mColl.onGround) || mColl.onGround)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            counter = fallWallCounter;
        }


        if (mColl.onWall && !mColl.onGround)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            if (counter <= 0)
            {
                if (mColl.onWall && mColl.onRightWall)
                {
                    JumpingFromWall();
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
                else if (mColl.onWall && mColl.onLeftWall)
                {
                    JumpingFromWall();
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
            }
            else if (counter >= 0)
                counter -= Time.deltaTime * 2;


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
    }

    private void WallJump()
    {
        JumpingFromWall();
        rb.velocity = new Vector2(rb.velocity.x, 0);
        if (mColl.onRightWall)
        {
            rb.velocity = new Vector2(-speed, jumpForce);
        }
        else if (mColl.onLeftWall)
        {
            rb.velocity = new Vector2(speed, jumpForce);
        }
    }

    void JumpingFromWall()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        wallJumping = true;
        StartCoroutine(SetWalljumpingFalse());
    }

    #endregion

    IEnumerator SetWalljumpingFalse()
    {
        yield return new WaitForSeconds(0.09f);
        wallJumping = false;
    }
}
