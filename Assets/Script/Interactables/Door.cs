using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool accepted;
    public bool canAccept;

    Collider2D personCollider;

    private void Start() {
        accepted = false;
        canAccept = false;
        personCollider = GameObject.Find("control").GetComponent<Collider2D>();
    }
    
}
