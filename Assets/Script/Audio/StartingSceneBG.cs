using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSceneBG : MusicPlayingUtilities
{
    public AudioClip clip;

    void Start()
    {
        StartCoroutine(LoopAudio(clip));
    }

}
