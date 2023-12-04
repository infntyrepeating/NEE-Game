using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenVaseScript : MonoBehaviour
{
    public void StartFadeAndDestroy(float fadeDuration)
    {
        StartCoroutine(FadeOutAndDestroy(fadeDuration));
    }

    private IEnumerator FadeOutAndDestroy(float duration)
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        float elapsedTime = 0f;
        Color startColor = renderer.color;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            renderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject); // Destroy the broken object
    }
}
