using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Compnents to get
    public AnimCon mAnimCon;
    public Rigidbody2D mRigidBody;
    public Collider2D mCollider;
    public Transform mTransform;



    // Variable to hold the sate of the character
    public bool canWalk;
    public bool canJump;
    public bool onGround;

    // Usefull Functions for characters
    public void flipSprite(Transform mtransform)
    {
        mtransform.localScale = new Vector2(Mathf.Sign(mRigidBody.velocity.x), 1f);
    }

}
