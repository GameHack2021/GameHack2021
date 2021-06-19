using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayingUtilities : MonoBehaviour
{
    AudioSource audioSource;

    public bool stopPlaying;
    public IEnumerator LoopAudio(AudioClip audioClip)
    {
        audioSource = GetComponent<AudioSource>();
        float length = audioClip.length;
        while (true)
        {
            audioSource.PlayOneShot(audioClip, 0.4f);
            yield return new WaitForSeconds(length);
        }
    }

    public IEnumerator LoopFootStep(AudioClip audioClip1, AudioClip audioClip2)
    {
        audioSource = GetComponent<AudioSource>();
        float length1 = audioClip1.length;
        float length2 = audioClip2.length;
        print(length1);
        while (true)
        {
            if (stopPlaying)
            {
                stopPlaying = false;
                break;
            }
            audioSource.PlayOneShot(audioClip1, 1f);
            yield return new WaitForSeconds(length1);
            audioSource.PlayOneShot(audioClip2, 1f);
            yield return new WaitForSeconds(length2);
        }
    }
}
