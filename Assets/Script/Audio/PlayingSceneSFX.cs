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
    public AudioClip landing;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void playJumping()
    {
        playAtVolume(jumping, 0.03f);
    }
    public void playLanding()
    {
        playAtVolume(landing, 0.2f);
    }
    public void startPlayingFootstep()
    {
        StartCoroutine(LoopFootStep(footstep_01, footstep_02)) ;
    }

    public void stopPlayingFootstep()
    {
        allowPlaying = true;
    }
}
