using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSceneBG : MusicPlayingUtilities
{
    public AudioClip clip;
    public AudioClip clipTV;
    public AudioClip clipSpark;

    void Start()
    {
        StartCoroutine(LoopAudio(clip, 0.1f));
        if(clipTV != null)
        {
            StartCoroutine(LoopAudioTV(clipTV, 0.1f));
        }
        if (clipSpark != null)
        {
            StartCoroutine(LoopAudioTV(clipSpark, 0.05f));
        }
    }

}
