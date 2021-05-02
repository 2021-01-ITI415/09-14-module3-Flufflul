using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollect : MonoBehaviour
{
    [SerializeField] public AudioSource     pickupSource;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("NoteCollectible")) {
            Debug.Log("Note found.");

            pickupSource.Play();

            other.gameObject.SetActive(false);
            StatController.notes++;
            StatController.S.updateStats();

            StatController.debugCollect();
        } 
        else if (other.gameObject.CompareTag("SinglePlayAudio")) {
            other.enabled = false;
        }
        else {
            Debug.Log("Untagged trigger");
        }
    }
}
