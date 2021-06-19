using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip room_of_computers;
    AudioSource audioSource;
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.PlayOneShot(room_of_computers, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
