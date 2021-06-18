using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    void Start()
    {

        mAnimator = GetComponent<Animator>();
        mRigidBody = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<Collider2D>();
        mTransform = GetComponent<Transform>();

        // TODO: can later be a intialize class function
        canWalk = true;
        canJump = true;
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Flip the picture when turning around
        flipSprite(mTransform);
    }

    // Manage the state of the player
    void stateDetect(){
         if(!onGround){
             canJump = false;
         }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == LayerMask.GetMask("Ground")){
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.layer == LayerMask.GetMask("Ground")){
            onGround = false;
        }
    }
}
