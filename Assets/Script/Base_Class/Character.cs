using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Animator mAnimator;
    public Rigidbody2D mRigidBody;
    public Collider2D mCollider;
    

    private void Start() {
        mAnimator = GetComponent<Animator>();
        mRigidBody = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<Collider2D>();
    }

}
