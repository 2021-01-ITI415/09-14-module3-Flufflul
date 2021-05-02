using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveFader : MonoBehaviour
{
    public static ObjectiveFader S;
    private bool mFaded = false;
    public float duration = 0.4f;
    
    private void Start() {
        if (S == null) S = this;

        IEnumerator FadeInOut() {
            yield return new WaitForSeconds(1);
            Fade();
            yield return new WaitForSeconds(3);
            Fade();
        } StartCoroutine(FadeInOut());
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
