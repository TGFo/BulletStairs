using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab of the bullet
    public Transform firePoint;      // Where the bullets spawn
    public float bulletSpeed = 5f;   // Speed of the bullets
    public float fireRate = 1f;      // How often bullets are fired

    private float fireTimer;
    public Transform playerLocation;

    private void Start()
    {
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;  // Find the player's location by tag
    }

    void Update()
    {
        // Handle the timing for firing bullets
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0)
        {
            FireBulletPattern();
            fireTimer = 1f / fireRate;  // Reset the fire timer
        }
    }

    // Fire different bullet patterns (all aimed in the player's general direction)
    void FireBulletPattern()
    {
        int rnd = Random.Range(0, 3);
        switch (rnd)
        {
            case 0:
                FireCircularSpread(12);
                break;
            case 1:
                FireDirectionalSpread(5, 45);
                break;
            case 2:
                FireStraightLineSpray(10);  // Fire multiple bullets in a straight line towards the player
                break;
        }
    }

    // Fire bullets in a circular spread pattern, centered towards the player
    void FireCircularSpread(int numBullets)
    {
        // Calculate direction towards player
        Vector2 directionToPlayer = (playerLocation.position - firePoint.position).normalized;

        // Get the angle towards the player
        float baseAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Fire bullets in a circular spread around the player's direction
        float angleStep = 360f / numBullets;
        float currentAngle = baseAngle;  // Centered on the player

        for (int i = 0; i < numBullets; i++)
        {
            // Calculate the direction based on the current angle
            float bulletDirX = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
            float bulletDirY = Mathf.Sin(currentAngle * Mathf.Deg2Rad);

            Vector2 bulletDirection = new Vector2(bulletDirX, bulletDirY).normalized;

            // Spawn the bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0, 0, currentAngle)));
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;

            currentAngle += angleStep;
        }
    }

    // Fire bullets in a directional spread pattern, centered towards the player
    void FireDirectionalSpread(int numBullets, float spreadAngle)
    {
        // Calculate direction towards player
        Vector2 directionToPlayer = (playerLocation.position - firePoint.position).normalized;

        // Get the base angle towards the player
        float baseAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Fire bullets in a directional spread pattern, centered on the player
        float angleStep = spreadAngle / (numBullets - 1);
        float startAngle = baseAngle - spreadAngle / 2;  // Centered on the player

        for (int i = 0; i < numBullets; i++)
        {
            // Calculate the direction based on the current angle
            float bulletDirX = Mathf.Cos(startAngle * Mathf.Deg2Rad);
            float bulletDirY = Mathf.Sin(startAngle * Mathf.Deg2Rad);

            Vector2 bulletDirection = new Vector2(bulletDirX, bulletDirY).normalized;

            // Spawn the bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0, 0, startAngle)));
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;

            startAngle += angleStep;
        }
    }

    // Fire multiple bullets in a straight line spray towards the player
    void FireStraightLineSpray(int numBullets)
    {
        // Calculate the direction towards the player
        Vector2 directionToPlayer = (playerLocation.position - firePoint.position).normalized;

        // Get the base angle towards the player
        float baseAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Adjust this value to space bullets further apart
        float bulletSpreadDistance = 1f;  // Increase this value to space bullets further apart

        for (int i = 0; i < numBullets; i++)
        {
            // Offset the bullets further apart by increasing bulletSpreadDistance
            float offset = i * bulletSpreadDistance - ((numBullets - 1) * bulletSpreadDistance / 2);  // Adjust the spread to center bullets

            Vector3 bulletSpawnPosition = firePoint.position + new Vector3(offset, 0, 0);

            // Spawn the bullet and rotate it to face the player
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.Euler(new Vector3(0, 0, baseAngle)));

            // Increase bullet speed if necessary, or just use a fixed higher speed
            float adjustedBulletSpeed = bulletSpeed * 1.5f;  // Increase the speed here
            bullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * adjustedBulletSpeed;
        }
    }
}

