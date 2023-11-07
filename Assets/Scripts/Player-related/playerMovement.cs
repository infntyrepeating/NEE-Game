using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    // PLAYER STATS
    public float MoveSpeed = 1.0f;
    public float DashRange = 5.0f;
    public float DashCooldown = 30.0f;

    // PLAYER ANIMATION
    public Animator PlayerAnimation;


    // PRIVATE VARIABLES
    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create a movement vector based on the input
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Move the player
        body.velocity = new Vector2(movement.x * MoveSpeed, movement.y * MoveSpeed);

        // You can also restrict diagonal movement to have the same speed as horizontal/vertical
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
