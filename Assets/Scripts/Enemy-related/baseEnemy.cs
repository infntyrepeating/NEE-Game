using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseEnemy : MonoBehaviour
{
    public Transform areaStart;
    public Transform areaEnd;
    public float movementSpeed = 3f;
    public float detectionRange = 5f;
    public LayerMask playerLayer;

    private Transform targetArea;
    private bool movingToStart = true;

    private void Start()
    {
        targetArea = areaStart;
    }

    private void Update()
    {
        MoveToTargetArea();
        CheckPlayerProximity();
    }

    private void MoveToTargetArea()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetArea.position, step);

        if (transform.position == targetArea.position)
        {
            if (targetArea == areaStart)
            {
                targetArea = areaEnd;
                movingToStart = false;
            }
            else
            {
                targetArea = areaStart;
                movingToStart = true;
            }
        }
    }

    private void CheckPlayerProximity()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange, playerLayer);
        if (colliders.Length > 0)
        {
            Debug.Log("Player is close!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
