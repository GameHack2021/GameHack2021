using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectNeighbor : MonoBehaviour
{
    
    private void Update() {
        if(GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Neighbor"))){
            transform.parent.GetComponent<Door>().canAccept = false;
        }else{
            transform.parent.GetComponent<Door>().canAccept = true;
        }
    }
}
