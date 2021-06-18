using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public int catsCreated;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        int catTaken = other.transform.GetComponent<Player_Interaction>().catsToTake;
        
        if(other.gameObject.tag == "Player" && (catTaken < catsCreated)){
            catsCreated = catsCreated - catTaken;
        }else{
            // TODO: show there are no more cats to be taken
        }
    }

    // TODO: Function to generate the number of cats


}
