using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Interaction : MonoBehaviour
{
    Player player;
    public Text catNumber;

    // Interaction objects variablex
    public int catsToTake;
    public int cat_Carried;
    bool canTakeCats;

    private void Awake()
    {
        //catNumber = GameObject.Find("Canvas/MainSceneUI/catNumber").GetComponent<Text>();
    }

    void Start()
    {
        player = GetComponent<Player>();

        // initialize variables
        canTakeCats = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        catNumber.text = "Cats left: " + cat_Carried;
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
    }
}
