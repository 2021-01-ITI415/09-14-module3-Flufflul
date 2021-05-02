using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRespectiveAudio : MonoBehaviour
{
    [SerializeField] public AudioSource     audioSource;

    private void OnTriggerEnter(Collider other) {
        audioSource.Play();
    }
}
