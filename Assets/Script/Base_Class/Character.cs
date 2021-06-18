using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator mAnimator;
    public Rigidbody2D mRigidBody;
    public Collider2D mCollider;
    public Transform mTransform;
    

    // Usefull Functions for characters
    public void flipSprite(Transform mtransform)
    {
        mtransform.localScale = new Vector2(Mathf.Sign(mRigidBody.velocity.x), 1f);
    }

}
