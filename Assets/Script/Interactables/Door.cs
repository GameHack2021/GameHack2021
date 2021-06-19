using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool accepted;
    public bool canAccept;
    public bool canDeliver;

    Collider2D personCollider;
    Player_Interaction player_Interaction;

    public GameObject floatCat;


    private void Start() {
        accepted = false;
        canAccept = false;
        personCollider = GameObject.Find("control").GetComponent<Collider2D>();
        player_Interaction = GameObject.Find("Player").GetComponent<Player_Interaction>();
    }

    private void Update() {
        if(!accepted){
            if(canDeliver && Input.GetButtonDown("Fire1")){
                if(canAccept){
                    accepted = true;
                    player_Interaction.cat_Carried = player_Interaction.cat_Carried -1;
                    // Debug.Log("accepted");
                }else{
                    Debug.Log("rejuect");
                    GameObject temp = Instantiate(floatCat,transform);
                    temp.transform.localPosition = new Vector3(0,0,0);
                }
            }
        }
        
        if(accepted){
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

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
