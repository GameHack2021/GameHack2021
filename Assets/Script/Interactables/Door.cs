using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool accepted;
    public bool canAccept;
    public bool canDeliver;

    Collider2D personCollider;

    private void Start() {
        accepted = false;
        canAccept = false;
        personCollider = GameObject.Find("control").GetComponent<Collider2D>();
    }

    private void Update() {
        if(!accepted){
            if(canDeliver && Input.GetButtonDown("Fire1")){
                if(canAccept){
                    accepted = true;
                    Debug.Log("accepted");
                }else{
                    // TODO:Player rejectanimation
                }
            }
        }
        
        if(accepted){
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(gameObject.tag);
        if(other.gameObject.tag == "Player"){
            canDeliver = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            canDeliver = false;
        }
    }
    
}
