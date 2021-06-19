using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    public float minChasingDistanceInX = 4.0f;
    public float minChasingDistanceInY = 3.5f;
    public float chasingSpeed = 2.0f;
    public float jumpingVel = 12f;

    GameObject player;
    Rigidbody2D rb;
    Collider2D playerCollider;
    Collider2D myCollider;
    
    float previousY = 0;
    Vector2 direction = new Vector2();
    float dstX = 0;
    float dstY = 0;

    bool jumping = false;
    bool focused = false;
    private void Awake()
    {
        player = GameObject.Find("Player");
        playerCollider = player.GetComponent<Collider2D>();
        myCollider = GetComponent<Collider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(playerCollider, myCollider, true);
    }
    private void Update()
    {
        direction = (player.transform.position - transform.position);
        dstX = Mathf.Abs(player.transform.position.x - transform.position.x);
        dstY = Mathf.Abs(player.transform.position.y - transform.position.y);

        if (focused)
            CounterMovement();
        else
            CheckFocus();
    }

    void CounterMovement()
    {
        if (dstX >= minChasingDistanceInX)
            ChaseInX(dstX);
        if (dstY >= minChasingDistanceInY)
            ChaseInY(dstY);
    }

    void ChaseInX(float dst)
    {
        float xDirection;

        if (direction.x > 0)
        {
            xDirection = 1;
        }
        else
        {
            xDirection = -1;
        }

        Vector2 aimVelocity = new Vector2();
        aimVelocity.x = xDirection * chasingSpeed * (dst - minChasingDistanceInX);
        aimVelocity.y = rb.velocity.y;

        rb.velocity = aimVelocity;
    }

    void ChaseInY(float dst)
    {
        if (dst - previousY < 0 && !jumping)    
        {
            Vector2 aimVelocity = new Vector2();
            aimVelocity.x = rb.velocity.x;
            aimVelocity.y = jumpingVel;
            jumping = true;
            rb.velocity = aimVelocity;
        }
        previousY = dst;
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false;
        CheckFocus();

    }

    void CheckFocus()
    {
        previousY = 0;
        if (dstX <= 10f && dstY <= 2f)
        {
            focused = true;
        }
        else
        {
            focused = false;
        }
    }
}
