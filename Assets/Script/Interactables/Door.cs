using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool accepted;

    private void Start() {
        accepted = false;
    }
    private void OnTriggerEnter2D(Collider2D other) {
       
    }

}
