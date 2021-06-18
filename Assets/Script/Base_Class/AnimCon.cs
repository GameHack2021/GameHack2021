using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCon
{
    Animator mAnimator;

    public AnimCon(Animator animator){
        mAnimator = animator;
    }
    public void changeAnim(string name,bool state){
        mAnimator.SetBool(name,state);
    }

    public void flipSprite(Transform mtransform){
        mtransform.localScale = new Vector2(Mathf.Sign(mtransform.gameObject.GetComponent<Rigidbody2D>().velocity.x), 1f);
    }
}
