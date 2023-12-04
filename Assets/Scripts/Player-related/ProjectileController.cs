using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Transform weaponPoint;
    public GameObject projectilePrefab;
    private Vector2 directionToMouse;
    public float bulletSpeed = 10f;

    private void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.x -= Screen.width/2;
        mousePos.y -= Screen.height/2;

        // Get the position of the mouse pointer in screen coordinates.
        Vector3 mousePosition = Input.mousePosition;

        // Convert the screen coordinates to a point in the game world.
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the direction vector from the center of the screen to the mouse position.
        directionToMouse = (Vector2)mousePos;

        directionToMouse.Normalize();
        // directionToMouse.x -= Screen.width/2;
        // directionToMouse.y -= Screen.height/2;

        // Normalize the direction vector if you only need the direction without the magnitude.
        //directionToMouse.Normalize();

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Quaternion rotation = Quaternion.identity;
        GameObject bullet = Instantiate(projectilePrefab, weaponPoint.position, rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = directionToMouse * bulletSpeed;

        Debug.Log(directionToMouse);
    }
}
