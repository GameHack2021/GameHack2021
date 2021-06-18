using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Variable to hold input value
    float input_Horizontal;
    float input_Vertical;

    // Refer to other class to get data
    Player player;

    // Properties
    [SerializeField] float walk_Velocity;

    void Start()
    {
        player = GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        getInputs();
        processInputs();
    }


    void getInputs(){
        input_Horizontal = Input.GetAxis("Horizontal");
        input_Vertical = Input.GetAxis("Vertical");
    }

    void processInputs(){

        Debug.Log(input_Horizontal);

        if(Mathf.Abs(input_Horizontal) > 0 && player.canWalk ){
            walk();
        }
    }

    void walk(){
        Vector2 updated_Velocity = new Vector2(input_Horizontal*walk_Velocity,player.mRigidBody.velocity.y);
        player.mRigidBody.velocity =updated_Velocity;
 
    }
}
