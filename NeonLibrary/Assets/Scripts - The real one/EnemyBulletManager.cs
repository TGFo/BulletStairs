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

    // Implement different bullet patterns below
    void FireBulletPattern()
    {
        // Example: Fire in a circular spread
        FireCircularSpread(12);  // Fire 12 bullets in a circular pattern
    }

    // Fire bullets in a circular spread pattern
    void FireCircularSpread(int numBullets)
    {
        float angleStep = 360f / numBullets;
        float angle = 0f;

        for (int i = 0; i < numBullets; i++)
        {
            float bulletDirX = Mathf.Cos((angle * Mathf.PI) / 180f);
            float bulletDirY = Mathf.Sin((angle * Mathf.PI) / 180f);

            Vector2 bulletDirection = new Vector2(bulletDirX, bulletDirY).normalized;

            // Spawn the bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;

            angle += angleStep;
        }
    }

    // Fire bullets in a directional spread
    void FireDirectionalSpread(int numBullets, float spreadAngle)
    {
        float angleStep = spreadAngle / (numBullets - 1);
        float angle = -spreadAngle / 2;

        for (int i = 0; i < numBullets; i++)
        {
            float bulletDirX = Mathf.Cos((angle * Mathf.PI) / 180f);
            float bulletDirY = Mathf.Sin((angle * Mathf.PI) / 180f);

            Vector2 bulletDirection = new Vector2(bulletDirX, bulletDirY).normalized;

            // Spawn the bullet
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;

            angle += angleStep;
        }
    }

    // Fire targeted bullets towards the player
    void FireTargetedBullets(Transform target)
    {
        Vector2 direction = (target.position - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}

