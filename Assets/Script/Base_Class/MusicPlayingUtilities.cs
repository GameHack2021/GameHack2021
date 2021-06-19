using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayingUtilities : MonoBehaviour
{
    AudioSource audioSource;
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
}
