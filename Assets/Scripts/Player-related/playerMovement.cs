using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // PLAYER STATS
    public float MoveSpeed = 5.0f;
    public float DashDuration = 0.2f;
    public float DashSpeedMultiplier = 5f; // Adjusted for faster dash
    public float DashCooldown = 1.0f;
    private bool isDashing = false;
    private Vector2 lastMovementDirection;
    private bool canDash = true;

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

        // Save the last movement direction
        if (movement != Vector2.zero)
        {
            lastMovementDirection = movement;
        }

        // Move the player
        if (!isDashing)
        {
            body.velocity = new Vector2(movement.x * MoveSpeed, movement.y * MoveSpeed);
        }

        // You can also restrict diagonal movement to have the same speed as horizontal/vertical
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.C) && !isDashing && canDash)
        {
            Dash();
        }
    }

    private void Dash()
    {
        isDashing = true;
        canDash = false;

        // Store the initial position for the dash
        Vector2 initialPosition = body.position;

        // Disable other movement during the dash
        // You might want to disable user input during the dash

        // Schedule the end of the dash after DashDuration seconds
        Invoke("EndDash", DashDuration);

        // Cooldown for dashing
        Invoke("ResetDash", DashCooldown);

        // Move the player with a higher speed directly for the dash duration
        StartCoroutine(DashMovement(initialPosition, initialPosition + lastMovementDirection * DashSpeedMultiplier));
    }

    private void EndDash()
    {
        // Restore normal movement or any other modifications you made during the dash
        // ...
        body.velocity = Vector2.zero;
        isDashing = false;
    }

    private void ResetDash()
    {
        canDash = true;
        Debug.Log("Can Dash!");
    }

    private System.Collections.IEnumerator DashMovement(Vector2 start, Vector2 end)
    {
        float elapsedTime = 0f;

        while (elapsedTime < DashDuration)
        {
            body.MovePosition(Vector2.Lerp(start, end, elapsedTime / DashDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is set
        body.MovePosition(end);
    }
}
