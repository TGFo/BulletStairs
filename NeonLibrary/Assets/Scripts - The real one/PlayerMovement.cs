using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of movement
    public float dashSpeed = 12f;            // Speed when dashing
    public float dashDuration = 0.5f;        // Duration of the dash in seconds
    public float dashCooldown = 1.0f;

    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;
    public float animThresholdSpeed = 1.0f;

    public bool isDashing = false;
    public float dashTime;                  // Timer to track dash duration
    public float dashCooldownTime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component attached to the GameObject
    }

    void Update()
    {
        // Get the input from the player (WASD or Arrow Keys)
        movement.x = Input.GetAxisRaw("Horizontal");  // Input on the X-axis (left/right)
        movement.y = Input.GetAxisRaw("Vertical");    // Input on the Y-axis (up/down)

        if (Input.GetKeyDown(KeyCode.LeftShift) && movement != Vector2.zero && Time.time >= dashCooldownTime)
        {
            isDashing = true;
            dashTime = Time.time + dashDuration;       // Set the dash duration
            dashCooldownTime = Time.time + dashCooldown;  // Set the dash cooldown
        }

        if (rb.velocity.x <= -animThresholdSpeed)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rb.velocity.x >= animThresholdSpeed)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void FixedUpdate()
    {
        if (isDashing && Time.time <= dashTime)
        {
            // Dash movement
            rb.velocity = movement.normalized * dashSpeed;  // Apply high-speed movement in the direction
        }
        else
        {
            // Regular movement
            rb.AddForce(movement * moveSpeed);
            isDashing = false; // Stop dashing once the dash time is over
        }
        if (rb.velocity.magnitude >= animThresholdSpeed )
        {
            animator.SetBool("isMoving", true);
        }else
        {
            animator.SetBool("isMoving", false);
        }
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}