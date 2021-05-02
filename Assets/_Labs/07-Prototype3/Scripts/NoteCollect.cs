using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("NoteCollectible")) {
            Debug.Log("Note found.");

            other.gameObject.SetActive(false);
            StatController.notes++;
            StatController.S.updateStats();

            StatController.debugCollect();
        } 
        else {
            Debug.Log("Untagged trigger");
        }
    }
}
