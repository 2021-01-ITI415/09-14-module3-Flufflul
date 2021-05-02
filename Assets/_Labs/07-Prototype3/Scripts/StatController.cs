using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour
{
    public static StatController    S;
    public static int               notes,
                                    totalNotes;
    
    public Text                     text_noteCount,
                                    text_objective;

    private void Start() {
        if (S == null) S = this;

        notes = 0;

        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("NoteCollectible");
        totalNotes = collectibles.Length;

        string objective = "- Find all " + totalNotes + " notes -";
        text_objective.text = objective;

        updateStats();

        ObjectiveFader.S.Fade();
        
    }

    public void updateStats() {
        string noteCount = notes + "/" + totalNotes;
        text_noteCount.text = noteCount;
    }

    public static void debugCollect() {
        Debug.Log("Collected notes: " + notes + "/" + totalNotes);
    }
}
