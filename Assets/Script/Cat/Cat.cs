using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Collectable
{
    Rigidbody2D rb;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 3f);
        Destroy(gameObject, 20);

    }
   
   private void Update() {
       rb.velocity = new Vector2(0, 3f);
   }
}
