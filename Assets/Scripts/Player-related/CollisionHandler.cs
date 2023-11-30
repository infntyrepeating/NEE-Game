using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject[] objectsToEnable;
    public GameObject[] objectsToDisable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Enable objects
            foreach (GameObject obj in objectsToEnable)
            {
                obj.SetActive(true);
            }

            // Disable this object
            gameObject.SetActive(false);

            // Disable other objects
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
            }
        }
    }
}
