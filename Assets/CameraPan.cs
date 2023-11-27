using System.Collections;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public Transform targetPoint; // The specific point you want the camera to pan to
    public GameObject objectToDisable; // The game object you want to disable
    public string scriptToDisable = "CameraFollow"; // The name of the script to disable

    private Camera mainCamera;
    private bool isColliding = false;
    private MonoBehaviour cameraFollowScript;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        mainCamera = Camera.main;
        cameraFollowScript = FindObjectOfType(typeof(cameraFollow)) as MonoBehaviour;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isColliding)
        {
            isColliding = true;

            // Disable the specified script
            if (cameraFollowScript != null)
            {
                cameraFollowScript.enabled = false;
            }

            StartCoroutine(PanCamera());
        }
    }

    IEnumerator PanCamera()
    {
        Vector3 originalPosition = mainCamera.transform.position;
        float duration = 1.5f;

        while (Vector3.Distance(mainCamera.transform.position, targetPoint.position) > 0.1f)
        {
            mainCamera.transform.position = Vector3.SmoothDamp(
                mainCamera.transform.position,
                targetPoint.position,
                ref velocity,
                duration
            );
            yield return null;
        }

        // Disable the renderer of the specified game object
        Renderer objectRenderer = objectToDisable.GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            objectRenderer.enabled = false;
        }

        // Wait for 3 seconds
        yield return new WaitForSeconds(1.5f);

        // Pan the camera back to its original position
        while (Vector3.Distance(mainCamera.transform.position, originalPosition) > 0.1f)
        {
            mainCamera.transform.position = Vector3.SmoothDamp(
                mainCamera.transform.position,
                originalPosition,
                ref velocity,
                duration
            );
            yield return null;
        }

        // Re-enable the specified script
        if (cameraFollowScript != null)
        {
            cameraFollowScript.enabled = true;
        }

        // Re-enable the renderer of the specified game object
        if (objectRenderer != null)
        {
            objectRenderer.enabled = true;
        }

        isColliding = false;
    }
}

