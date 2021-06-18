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
    [SerializeField] float jump_Velocity_H;

    // Variables to record current
    
    // Change depends on the state
    float current_Velocity_H;

    void Start()
    {
        player = GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        velocity_Control();
        getInputs();
        processInputs();
    }


    void getInputs(){
        input_Horizontal = Input.GetAxis("Horizontal");
        input_Vertical = Input.GetAxis("Vertical");

        input_Jump = Input.GetButtonDown("Jump");
    }

    void processInputs(){

        if(Mathf.Abs(input_Horizontal) > 0 ){
            move_H();
        }

        if(input_Jump && player.canJump){
            jump();
        }
    }

    void velocity_Control(){
        if(player.canWalk){
            current_Velocity_H = walk_Velocity;
        }

        if(player.canJump){
            current_Velocity_H = jump_Force;
        }
    }


    // Controll players horizontal move
    void move_H(){
        Vector2 updated_Velocity = new Vector2(input_Horizontal*current_Velocity_H,player.mRigidBody.velocity.y);
        player.mRigidBody.velocity =updated_Velocity;
 
    }

    void jump(){
        Vector2 updated_Velocity = new Vector2(player.mRigidBody.velocity.x, jump_Force);
        player.mRigidBody.velocity = updated_Velocity;
    }
}
