using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndFader : MonoBehaviour
{
    public static GameEndFader S;
    private bool mFaded = true;
    public float duration = 0.4f;
    
    private void Start() {
        if (S == null) S = this;
    }

    public void GameEndFade() {
        IEnumerator FadeOut() {
            yield return new WaitForSeconds(2);
            Fade();
        } StartCoroutine(FadeOut());
    }

    public void Fade() {
        var canvGroup = GetComponent<CanvasGroup>();

        // Toggle end value depending on faded state
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));

        // Toggle faded state
        mFaded = !mFaded;
    }

    public IEnumerator DoFade(CanvasGroup canvasGroup, float start, float end) {
        float counter = 0f;

        while (counter < duration) {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / duration);

            yield return null;
        }
    }
}