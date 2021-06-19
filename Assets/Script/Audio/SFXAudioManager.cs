using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudioManager : MonoBehaviour
{
    public AudioClip door_close;
    public AudioClip door_open;
    public AudioClip jumping;
    AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playJumping()
    {
        audioSource.PlayOneShot(jumping, 1f);
    }
}
