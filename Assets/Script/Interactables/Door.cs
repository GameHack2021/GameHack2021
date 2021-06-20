using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public bool accepted;
    public bool canAccept;
    public bool canDeliver;
    
    Text canDeliverHint;

    Collider2D personCollider;
    Player_Interaction player_Interaction;

    public GameObject floatCat;


    private void Awake() {
        accepted = false;
        canAccept = false;
        personCollider = GameObject.Find("control").GetComponent<Collider2D>();
        player_Interaction = GameObject.Find("Characters/Player_Armor").GetComponent<Player_Interaction>();
        canDeliverHint = GameObject.Find("Canvas/hintText").GetComponent<Text>();
    }

    private void Start()
    {
        canDeliverHint.gameObject.SetActive(false);
    }

    private void Update() {
        if(!accepted){
            if(canDeliver && Input.GetButtonDown("Fire1")){
                if(canAccept){
                    accepted = true;
                }else{
                    GameObject temp = Instantiate(floatCat,transform);
                    temp.transform.localPosition = new Vector3(0,0.42f,0);
                }

                player_Interaction.cat_Carried = player_Interaction.cat_Carried -1;
            }
        }
        
        if(accepted){
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player"){
            canDeliver = true;
            canDeliverHint.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            canDeliver = false;
            canDeliverHint.gameObject.SetActive(false) ;
        }
    }
    
}
