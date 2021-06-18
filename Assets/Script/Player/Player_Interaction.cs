using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    Player player;
    
    // Interaction objects variable
    int cat_Carried;

    void Start()
    {
        player = GetComponent<Player>();

        // initialize variables
        cat_Carried = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Cat"){
            cat_Carried = cat_Carried + 1;
        }

        Debug.Log("Carried cat:"+cat_Carried);
    }
}
