using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab of the bullet
    public Transform firePoint;      // Where the bullets spawn
    public float bulletSpeed = 10f;   // Base speed of the bullets
    public float fireRate = 0.5f;      // How often bullets are fired
    public float speedMultiplier = 3f; // To increase bullet speed across all patterns

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
        int rnd = Random.Range(0, 5);  // Increased the range to include new patterns
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
            case 3:
                FireSpiralPattern(12, 3);   // New spiral pattern
                break;
            case 4:
                FireBurstPattern(8);        // New burst pattern
                break;
        }
    }

    // Fire bullets in a circular spread pattern, centered towards the player
    void FireCircularSpread(int numBullets)
    {
        Vector2 directionToPlayer = (playerLocation.position - firePoint.position).normalized;
        float baseAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        float angleStep = 360f / numBullets;
        float currentAngle = baseAngle;  // Centered on the player

        for (int i = 0; i < numBullets; i++)
        {
            float bulletDirX = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
            float bulletDirY = Mathf.Sin(currentAngle * Mathf.Deg2Rad);

            Vector2 bulletDirection = new Vector2(bulletDirX, bulletDirY).normalized;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0, 0, currentAngle)));
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed * speedMultiplier;  // Apply the speed multiplier

            currentAngle += angleStep;
        }
    }

    // Fire bullets in a directional spread pattern, centered towards the player
    void FireDirectionalSpread(int numBullets, float spreadAngle)
    {
        Vector2 directionToPlayer = (playerLocation.position - firePoint.position).normalized;
        float baseAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        float angleStep = spreadAngle / (numBullets - 1);
        float startAngle = baseAngle - spreadAngle / 2;  // Centered on the player

        for (int i = 0; i < numBullets; i++)
        {
            float bulletDirX = Mathf.Cos(startAngle * Mathf.Deg2Rad);
            float bulletDirY = Mathf.Sin(startAngle * Mathf.Deg2Rad);

            Vector2 bulletDirection = new Vector2(bulletDirX, bulletDirY).normalized;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0, 0, startAngle)));
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed * speedMultiplier;

            startAngle += angleStep;
        }
    }

    // Fire multiple bullets in a straight line spray towards the player
    void FireStraightLineSpray(int numBullets)
    {
        Vector2 directionToPlayer = (playerLocation.position - firePoint.position).normalized;
        float baseAngle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        float bulletSpreadDistance = 1f;  // Space bullets apart

        for (int i = 0; i < numBullets; i++)
        {
            float offset = i * bulletSpreadDistance - ((numBullets - 1) * bulletSpreadDistance / 2);  // Center bullets
            Vector3 bulletSpawnPosition = firePoint.position + new Vector3(offset, 0, 0);

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.Euler(new Vector3(0, 0, baseAngle)));
            bullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * bulletSpeed * 1.5f * speedMultiplier;
        }
    }

    // New spiral pattern: bullets are fired in a rotating spiral
    void FireSpiralPattern(int numBullets, int rotations)
    {
        float currentAngle = 0f;
        float angleStep = 360f / numBullets;

        for (int r = 0; r < rotations; r++)
        {
            for (int i = 0; i < numBullets; i++)
            {
                float bulletDirX = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
                float bulletDirY = Mathf.Sin(currentAngle * Mathf.Deg2Rad);

                Vector2 bulletDirection = new Vector2(bulletDirX, bulletDirY).normalized;

                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(new Vector3(0, 0, currentAngle)));
                bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed * speedMultiplier;

                currentAngle += angleStep;
            }
        }
    }

    // New burst pattern: rapidly fires multiple bullets towards the player
    void FireBurstPattern(int burstCount)
    {
        Vector2 directionToPlayer = (playerLocation.position - firePoint.position).normalized;

        for (int i = 0; i < burstCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * bulletSpeed * (speedMultiplier + i);  // Each bullet gets faster
        }
    }
}

