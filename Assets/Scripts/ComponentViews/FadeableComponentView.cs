using UnityEngine;
using System.Collections;


public abstract class FadeableComponentView : ComponentView
{
    public CanvasGroup canvasGroup;
    private float time;

    public virtual void FadeOut(float time)
    {
        this.time = time;
        StartCoroutine("FadeOutCoroutine");
    }

    IEnumerator FadeOutCoroutine()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }

    public virtual void FadeIn(float time)
    {
        this.time = time;
        StartCoroutine("FadeInCoroutine");
    }

    IEnumerator FadeInCoroutine()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / time;
            yield return null;
        }
    }
}