using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    public float moveSpeed = 2f;             // Speed of the enemy movement
    public float directionChangeInterval = 3f;  // Time interval between direction changes
    public float maxRandomAngle = 360f;      // Max angle change for random direction

    private Rigidbody2D rb;
    private Vector2 movement;
    private float directionChangeTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    // Get the Rigidbody2D component attached to Enemy1
        ChangeDirection();                   // Set initial random direction
        directionChangeTimer = directionChangeInterval;
    }

    void Update()
    {
        // Update the direction change timer
        directionChangeTimer -= Time.deltaTime;

        // Change direction once the timer reaches 0
        if (directionChangeTimer <= 0)
        {
            ChangeDirection();
            directionChangeTimer = directionChangeInterval;
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Function to change the enemy's movement direction randomly
    void ChangeDirection()
    {
        // Generate a random angle in radians and convert it to a direction vector
        float randomAngle = Random.Range(0f, maxRandomAngle) * Mathf.Deg2Rad;
        movement = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;
    }
}
