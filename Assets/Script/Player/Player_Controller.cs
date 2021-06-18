using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Variable to hold input value
    float input_Horizontal;
    float input_Vertical;
    bool input_Jump;


    // Refer to other class to get data
    Player player;

    // Properties
    [SerializeField] float walk_Velocity;
    [SerializeField] float jump_Force;

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

        input_Jump = Input.GetButtonDown("Jump");
    }

    void processInputs(){

        if(Mathf.Abs(input_Horizontal) > 0 && player.canWalk ){
            walk();
        }

        if(input_Jump && player.canJump){
            jump();
        }
    }

    void walk(){
        Vector2 updated_Velocity = new Vector2(input_Horizontal*walk_Velocity,player.mRigidBody.velocity.y);
        player.mRigidBody.velocity =updated_Velocity;
 
    }

    void jump(){
        Vector2 updated_Velocity = new Vector2(player.mRigidBody.velocity.x, jump_Force);
        player.mRigidBody.velocity = updated_Velocity;
    }
}
