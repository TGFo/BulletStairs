using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of movement
    public float dashSpeed = 12f;            // Speed when dashing
    public float dashDuration = 0.5f;        // Duration of the dash in seconds
    public float dashCooldown = 3.0f;

    private Rigidbody2D rb;
    private Vector2 movement;
    public Collider2D playerCollider;
    public Animator animator;
    public float animThresholdSpeed = 1.0f;

    public bool isDashing = false;
    public float dashTime;                  // Timer to track dash duration
    public float dashCooldownTime;
    public DoorUnlock doorUnlock;
    public TMP_Text dashTimerTxt;
    public GameObject dashIcon;
    public Transform characterTransform;
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
            animator.SetBool("isDashing", true);
            dashTime = Time.time + dashDuration;       // Set the dash duration
            dashCooldownTime = Time.time + dashCooldown;  // Set the dash cooldown
            playerCollider.enabled = false;
        }

        UpdateDashCooldownUI();

        if (rb.velocity.x <= -animThresholdSpeed)
        {
            characterTransform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rb.velocity.x >= animThresholdSpeed)
        {
            characterTransform.localScale = new Vector3(1, 1, 1);
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
            playerCollider.enabled = true;
            isDashing = false; // Stop dashing once the dash time is over
            animator.SetBool("isDashing", false);
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

    private void UpdateDashCooldownUI()
    {
        // Calculate the remaining cooldown time
        float remainingCooldown = dashCooldownTime - Time.time;

        // If the cooldown is still active, display the remaining time as an integer
        if (remainingCooldown > 0)
        {
            dashIcon.SetActive(false);
            dashTimerTxt.text = Mathf.CeilToInt(remainingCooldown).ToString();
        }
        else
        {
            // Clear the cooldown text when the dash is ready
            dashTimerTxt.text = "";
            dashIcon.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CamChange"))
        {
            switch (EnemyManager.instance.enemiesKilled)
            {
                case 0:
                    PlayerManager.instance.camera.orthographicSize = 20;
                    break;
                case 1:
                    PlayerManager.instance.camChanges[0].SetActive(false);
                    PlayerManager.instance.mainCamera.transform.position = new Vector3(70.15f, 0, -10);
                    doorUnlock.doorRelock[0] = true;
                    doorUnlock.doors[0].SetActive(true);
                    

                    break;
                case 2:
                    PlayerManager.instance.camChanges[1].SetActive(false);
                    PlayerManager.instance.mainCamera.transform.position = new Vector3(140.24f, 0, -10);
                    doorUnlock.doorRelock[1] = true;
                    doorUnlock.doors[1].SetActive(true);
                    break;
                case 3:
                    PlayerManager.instance.camChanges[2].SetActive(false);
                    PlayerManager.instance.mainCamera.transform.position = new Vector3(140.24f, 39.2f, -10);
                    doorUnlock.doorRelock[2] = true;
                    doorUnlock.doors[2].SetActive(true);
                    break;
                case 4:
                    PlayerManager.instance.camChanges[3].SetActive(false);
                    PlayerManager.instance.camChanges[4].SetActive(false);
                    PlayerManager.instance.mainCamera.transform.position = new Vector3(140.24f, 98.2f, -10);
                    PlayerManager.instance.camera.orthographicSize = 40;
                    doorUnlock.doorRelock[3] = true;
                    doorUnlock.doorRelock[4] = true;
                    doorUnlock.doors[3].SetActive(true);
                    doorUnlock.doors[4].SetActive(true);
                    break;
                default:
                    break;
            }
        }

    }
}