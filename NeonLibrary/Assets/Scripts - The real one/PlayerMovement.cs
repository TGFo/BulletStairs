using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of movement

    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component attached to the GameObject
    }

    void Update()
    {
        // Get the input from the player (WASD or Arrow Keys)
        movement.x = Input.GetAxisRaw("Horizontal");  // Input on the X-axis (left/right)
        movement.y = Input.GetAxisRaw("Vertical");    // Input on the Y-axis (up/down)
    }

    void FixedUpdate()
    {
        // Apply the movement to the Rigidbody2D
        rb.AddForce(movement * moveSpeed);
        if(rb.velocity.magnitude >= 5 )
        {
            animator.SetBool("isMoving", true);
        }else
        {
            animator.SetBool("isMoving", false);
        }
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}