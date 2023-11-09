using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;  // The GameObject the camera should follow
    public float smoothSpeed = 5.0f;  // The speed at which the camera follows the target
    public Vector3 offset = new Vector3(0, 0, -10);  // The offset of the camera from the target

    void LateUpdate()
    {
        if (target == null)
        {
            // Ensure the target is set
            Debug.LogWarning("Target is not set for CameraFollow script.");
            return;
        }

        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;
    }
}
