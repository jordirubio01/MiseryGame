using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour
{
    public Image fadeImage;          // El Image negro que cubre la pantalla
    public float fadeDuration = 1f;  // Duración del fade en segundos

    private void Awake()
    {
        // Empezar transparente
        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }
    }

    // Llamar para hacer fade out a negro
    public void StartFadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    public IEnumerator FadeOutCoroutine()
    {
        float timer = 0f;
        Color c = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

        // Asegurar alpha en 1
        c.a = 1f;
        fadeImage.color = c;
    }

    // Método opcional para fade in desde negro
    public void StartFadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        float timer = 0f;
        Color c = fadeImage.color;
        c.a = 1f;
        fadeImage.color = c;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

        // Asegurar alpha en 0
        c.a = 0f;
        fadeImage.color = c;
    }
}