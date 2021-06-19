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
            transform.parent.parent.GetComponent<Door>().canAccept = true;
        }
        if(timeStamp >= 14)
        {
            isThere = false;
            transform.parent.parent.GetComponent<Door>().canAccept = false;
        }
        print(timeStamp);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("hitsth");
        if(other.gameObject.tag == "Door"){
            Debug.Log("hitsth");
            transform.parent.parent.GetComponent<Door>().canAccept = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Box"){
            transform.parent.parent.GetComponent<Door>().canAccept = false;
        }
    }
}
