using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCollisions : MonoBehaviour
{
    public LayerMask groundLayer;

    [Space]

    [Range(0.1f, 1.0f)]
    public float radius = 0.2f;
    [Range(0.1f, 1.0f)]
    public float rightSideOff;
    [Range(0.1f, 1.0f)]
    public float leftSideOff;
    [Range(0.1f, 1.0f)]
    public float downSideOff;

    [Space]

    public bool onGround;
    public bool onWall;
    public bool onRightWall;
    public bool onLeftWall;
    //public int wallJumpSide;

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - downSideOff), radius, groundLayer);
        onWall = Physics2D.OverlapCircle(new Vector2(transform.position.x + rightSideOff, transform.position.y), radius, groundLayer) 
            || Physics2D.OverlapCircle(new Vector2(transform.position.x - leftSideOff, transform.position.y), radius, groundLayer);


        onRightWall = Physics2D.OverlapCircle(new Vector2(transform.position.x + rightSideOff, transform.position.y), radius, groundLayer);
        onLeftWall = Physics2D.OverlapCircle(new Vector2(transform.position.x - leftSideOff, transform.position.y), radius, groundLayer);

        //wallJumpSide = onRightWall ? -1 : 1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(new Vector3(transform.position.x + rightSideOff, transform.position.y), radius); //right gizmo
        Gizmos.DrawWireSphere(new Vector3(transform.position.x - leftSideOff, transform.position.y), radius); //left gizmo
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y - downSideOff), radius); //vertical gizmo
    }
}
