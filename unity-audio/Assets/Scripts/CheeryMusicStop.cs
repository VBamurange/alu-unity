using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeryMusicStop : MonoBehaviour
{
    public AudioSource cherryAudioSource;
    public AudioSource victoryAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (cherryAudioSource.isPlaying)
            {
                cherryAudioSource.Stop();
            }

            if (!victoryAudioSource.isPlaying)
            {
                victoryAudioSource.Play();
            }
        }
    }
}
