using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Variable to hold the sate of the player
    public bool canWalk;
    void Start()
    {

        mAnimator = GetComponent<Animator>();
        mRigidBody = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<Collider2D>();
        mTransform = GetComponent<Transform>();

        // TODO: can later be a intialize class function
        canWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Flip the picture when turning around
        flipSprite(mTransform);
    }
}
