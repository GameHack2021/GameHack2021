using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    Collider2D playerCollider;
    Collider2D myCollider;
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
        CounterMovement();
    }

    void CounterMovement()
    {
        float dst = Vector2.Distance(player.transform.position, transform.position);
        if (dst >= 4f)
            Chase(dst);
    }

    void Chase(float dst)
    {
        Vector2 direction = (player.transform.position - transform.position);
        Vector2 xDirection = new Vector2();
        Vector2 yDirection = new Vector2();
        xDirection.x = direction.x;
        xDirection = xDirection.normalized;
        yDirection.y = direction.y;
        yDirection = yDirection.normalized;

        rb.velocity = xDirection * 2f * (dst - 4);
    }
}
