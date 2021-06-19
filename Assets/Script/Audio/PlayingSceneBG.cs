using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingSceneBG : MusicPlayingUtilities
{
    public AudioClip spaceship;
    public AudioClip calm;
    public AudioClip joy;
    public AudioClip sadness;

    void Start()
    {
        StartCoroutine(LoopAudio(spaceship));
    }


}
