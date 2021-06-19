using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingSceneSFX : MusicPlayingUtilities
{
    public AudioClip door_close_1;
    public AudioClip door_close_2;
    public AudioClip door_open;
    public AudioClip footstep_01;
    public AudioClip footstep_02;
    public AudioClip jumping;
    AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playLanding()
    {
        audioSource.PlayOneShot(jumping, 1f);
    }

    public void startPlayingFootstep()
    {
        //StartCoroutine(LoopFootStep(footstep_01, footstep_02)) ;
        StartCoroutine(LoopAudio(footstep_01));
    }

    public void stopPlayingFootstep()
    {
        stopPlaying = true;
    }
}
