using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeighbourHideNSeek : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Collider2D putDownRangeCollider;

    // about 14s to run a full anim set
    Animator neighbourWalking;
    float timeStamp = 0;
    float minimalTime = 14f;
    float maximalTime = 20f;

    float nextRandomTime = 0;

    public bool isThere = true;
    public float eeTime = 13;
    private void Awake()
    {
        neighbourWalking = GetComponent<Animator>();
        nextRandomTime = Random.Range(minimalTime, maximalTime);
    }

    private void Update()
    {
        timeStamp += Time.deltaTime;
        CheckStartPlaying();
    }

    void CheckStartPlaying()
    {
        if (timeStamp >= 2 && timeStamp <= 3.5f)
        {
            neighbourWalking.SetBool("start", false);
        }
        if (timeStamp >= nextRandomTime)
        {
            neighbourWalking.SetBool("start", true);
            //print("It's him! He's there!");
            nextRandomTime = Random.Range(minimalTime, maximalTime);
            timeStamp = 0;
            isThere = true;
        }
        if(timeStamp >= eeTime)
        {
            isThere = false;
        }
        print(timeStamp);
    }
}
