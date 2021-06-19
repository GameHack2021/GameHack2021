using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayingUtilities : MonoBehaviour
{
    AudioSource audioSource;

    public bool allowPlaying;
    float volumeMultiplier = 1.0f;

    private void Awake()
    {
        allowPlaying = false;
    }

    private void Update()
    {
        // print(allowPlaying);

    }
    public IEnumerator LoopAudio(AudioClip audioClip, float volume)
    {
        audioSource = GetComponent<AudioSource>();
        float length = audioClip.length;
        while (true)
        {
            audioSource.PlayOneShot(audioClip, volume);
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
            if (allowPlaying)
            {
                if (playFirstOne)
                {
                    playFirstOne = false;
                    audioSource.PlayOneShot(audioClip1, 0.07f * volumeMultiplier);
                    yield return new WaitForSeconds(length1 * 3);
                }
                else
                {
                    playFirstOne = true;
                    audioSource.PlayOneShot(audioClip2, 0.10f * volumeMultiplier);
                    yield return new WaitForSeconds(length2 * 3);
                }
            }
            else
            {
                yield return null;
            }



        }
    }
}
