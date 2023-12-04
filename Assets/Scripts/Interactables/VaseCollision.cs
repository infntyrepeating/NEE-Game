using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseCollision : MonoBehaviour
{
    public GameObject brokenPrefab; // Assign the broken prefab in the Inspector
    public float fadeDuration = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            BreakObject();
        }
    }

    private void BreakObject()
    {
        GameObject brokenObject = Instantiate(brokenPrefab, transform.position, transform.rotation);
        BrokenVaseScript script = brokenObject.AddComponent<BrokenVaseScript>();
        script.StartFadeAndDestroy(fadeDuration);

        Destroy(gameObject); // Destroy the original object
    }
}

