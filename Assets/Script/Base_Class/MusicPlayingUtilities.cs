using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayingUtilities : MonoBehaviour
{
    AudioSource audioSource;

    public bool stopPlaying;

    private void Awake()
    {
        stopPlaying = false;
    }

    private void Update()
    {
            print(stopPlaying);

    }
    public IEnumerator LoopAudio(AudioClip audioClip)
    {
        audioSource = GetComponent<AudioSource>();
        float length = audioClip.length;
        while (true)
        {
            if (stopPlaying)
            {
                stopPlaying = false;
                break;
            }
            audioSource.PlayOneShot(audioClip, 0.4f);
            yield return new WaitForSeconds(length);
        }
    }

    public IEnumerator LoopFootStep(AudioClip audioClip1, AudioClip audioClip2)
    {
        bool playFirstOne = true;
        audioSource = GetComponent<AudioSource>();
        float length1 = audioClip1.length;
        float length2 = audioClip2.length;
        while (true)
        {
            if (stopPlaying)
            {
                stopPlaying = false;
                break;
            }
            if (playFirstOne)
            {
                playFirstOne = false;
                audioSource.PlayOneShot(audioClip1, 1f);

            }else
            {
                playFirstOne = true;
                audioSource.PlayOneShot(audioClip2, 1f);
            }
            yield return new WaitForSeconds(2);


        }
    }
}
