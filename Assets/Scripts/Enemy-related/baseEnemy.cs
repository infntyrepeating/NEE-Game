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
               
            }
            else
            {
                targetArea = areaStart;
                
            }
        }
    }

    private void CheckPlayerProximity()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, detectionRange);

        if (collider != null && collider.CompareTag("Player"))
        {
          Debug.Log("Player is close!!!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
