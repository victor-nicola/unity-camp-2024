using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Warning : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpText;
    private Coroutine fadeCoroutine;

    public void ShowWarning(string message, float displayTime = 3f)
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        fadeCoroutine = StartCoroutine(FadeText(message, displayTime));
    }

    private IEnumerator FadeText(string message, float displayTime)
    {
        float fadeDuration = displayTime * 0.2f;

        tmpText.text = message;
        yield return StartCoroutine(FadeIn(fadeDuration));

        yield return new WaitForSeconds(displayTime - 2 * fadeDuration);

        yield return StartCoroutine(FadeOut(fadeDuration));
    }

    private IEnumerator FadeIn(float fadeDuration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            SetTextAlpha(alpha);
            yield return null;
        }

        SetTextAlpha(1f);
    }

    private IEnumerator FadeOut(float fadeDuration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(1f - elapsedTime / fadeDuration);
            SetTextAlpha(alpha);
            yield return null;
        }

        SetTextAlpha(0f);
    }

    private void SetTextAlpha(float alpha)
    {
        Color color = tmpText.color;
        color.a = alpha;
        tmpText.color = color;
    }
}
