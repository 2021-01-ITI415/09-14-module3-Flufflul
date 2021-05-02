using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class StatController : MonoBehaviour
{
    public static StatController    S;
    public static int               notes,
                                    totalNotes;
    
    public Text                     text_noteCount,
                                    text_objective,
                                    text_victory;

    private void Start() {
        if (S == null) S = this;

        notes = 0;

        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("NoteCollectible");
        totalNotes = collectibles.Length;

        string objective = "- Find all " + totalNotes + " notes -";
        text_objective.text = objective;

        updateStats();
    }

    public void updateStats() {
        string noteCount = notes + "/" + totalNotes;
        text_noteCount.text = noteCount;

        checkEndCondition();
    }

    private void checkEndCondition() {
        if (StatController.notes == StatController.totalNotes) {
            IEnumerator finish() {
                GameEndFader.S.GameEndFade();
                text_victory.GetComponent<CanvasGroup>().alpha = 1;

                GameObject go = GameObject.Find("FPSController");
                FirstPersonController FPSController = go.GetComponent<FirstPersonController>();
                FPSController.UnfixMouseLock();
                Destroy(go);

                yield return new WaitForSeconds(5);
                SceneManager.LoadScene("MainMenu");
            } StartCoroutine(finish());
        }
    }

    public static void debugCollect() {
        Debug.Log("Collected notes: " + notes + "/" + totalNotes);
    }
}
