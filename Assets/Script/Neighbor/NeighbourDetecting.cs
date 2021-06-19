using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourDetecting : MonoBehaviour
{
    Animator neighbourWalking;
    float timeStamp = 0;
    float minimalTime = 7f;
    float maximalTime = 13f;

    float nextRandomTime = 0;
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
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {

        }
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
        }
    }
}
