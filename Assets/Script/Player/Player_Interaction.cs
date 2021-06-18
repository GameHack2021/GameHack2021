using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    Player player;
    
    // Interaction objects variablex
    public int catsToTake;
    int cat_Carried;
    bool canTakeCats;


    void Start()
    {
        player = GetComponent<Player>();

        // initialize variables
        cat_Carried = 0;
        canTakeCats = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Home"){
            if(canTakeCats){
                cat_Carried = cat_Carried + catsToTake;
            }
        }

        if(other.gameObject.tag == "Cat"){
            cat_Carried = cat_Carried + 1;
        }

        if(other.gameObject.tag == "Door"){
            if(!other.gameObject.GetComponent<Door>().accepted){
                other.gameObject.GetComponent<Door>().accepted = true;
                cat_Carried = cat_Carried -1;
            }
        }

        Debug.Log("Carried cat:"+cat_Carried);
    }
}
