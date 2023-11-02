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


    // PLAYER CONTROLS
    public KeyCode dash = KeyCode.L;
    public KeyCode up = KeyCode.W;
    public KeyCode right = KeyCode.D;
    public KeyCode left = KeyCode.A;
    public KeyCode down = KeyCode.S;


    // PRIVATE VARIABLES
    private Transform PlayerBody;
    private Rigidbody2D body;


    // Start is called before the first frame update
    void Start()
    {
        PlayerBody = GetComponent<Transform>();
        PlayerAnimation = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


        // PLAYER CONTROLS --- GOTTA WORK THIS BECAUSE I WAS USING A NON-COLLIDER SYSTEM, NEED TO CHANGE TO RIGIDBODY
        if (Input.GetKey(up)) {
            Vector3 movement = Vector3.up * MoveSpeed * Time.deltaTime;
            PlayerBody.Translate(movement);
        }
        if (Input.GetKey(down)) {
            Vector3 movement = Vector3.down * MoveSpeed * Time.deltaTime;
            PlayerBody.Translate(movement);
        }

        if (Input.GetKey(right)) {
            Vector3 movement = Vector3.right * MoveSpeed * Time.deltaTime;
            PlayerBody.Translate(movement);
        }
        if (Input.GetKey(left)) {
            Vector3 movement = Vector3.left * MoveSpeed * Time.deltaTime;
            PlayerBody.Translate(movement);
        }
    }
}
