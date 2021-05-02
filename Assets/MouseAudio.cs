using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public void PlayClip(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }
}
