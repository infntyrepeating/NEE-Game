using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public Rigidbody2D rb;

    public string targetLayerName = "Player";

    void Start()
    {
        int targetLayer = LayerMask.NameToLayer(targetLayerName);
        // Ignore collisions between the current object's layer and the target layer.
        Physics2D.IgnoreLayerCollision(gameObject.layer, targetLayer);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}