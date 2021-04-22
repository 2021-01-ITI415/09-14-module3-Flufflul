using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip            splashSound;
    public AudioSource          audioSource;
    public AudioMixerSnapshot   idleSnapshot, 
                                auxInSnapshot;
    public LayerMask            enemyMask;

    bool enemyNear;
    private void Update() {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 10f, transform.forward, 0f, enemyMask);
        if (hits.Length > 0) {
            if (!enemyNear) {
                auxInSnapshot.TransitionTo(0.5f);
                enemyNear = true;
            }
        }
        else {
            if (enemyNear) {
                idleSnapshot.TransitionTo(0.5f);                
                enemyNear = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Water")) {
            audioSource.PlayOneShot(splashSound);
        }

        if (other.CompareTag("EnemyZone")) {
            auxInSnapshot.TransitionTo(0.5f);
        }
    }

    private void OnTriggerExit(Collider other) {
       if (other.CompareTag("Water")) {
            audioSource.PlayOneShot(splashSound);
        }

        if (other.CompareTag("EnemyZone")) {
            idleSnapshot.TransitionTo(0.5f);
        }

    }
}
