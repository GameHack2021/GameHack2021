using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingSceneBG : MusicPlayingUtilities
{
    public AudioClip spaceship;
    public AudioClip calm;
    public AudioClip joy;
    public AudioClip sadness;
    public AudioClip night_amb;

    void Start()
    {
        StartCoroutine(LoopAudio(spaceship, 0.05f));
        StartCoroutine(LoopAudio(night_amb, 0.03f));
    }


}
