using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class catNumber : MonoBehaviour
{
    
    Player_Interaction player_Interaction;
    Text text;
    void Start(){
        player_Interaction = GameObject.Find("Player").GetComponent<Player_Interaction>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = player_Interaction.cat_Carried.ToString();
    }
}
