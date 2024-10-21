using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;  // Enemy's maximum health
    public int currentHealth;    // Enemy's current health
    public GameObject pickupPrefab;
    void Start()
    {
        currentHealth = maxHealth;  // Initialize the enemy's health
    }

    // Function to apply damage to the enemy
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Instantiate(pickupPrefab, this.gameObject.transform.position, Quaternion.identity);
            Die();  // Call the die function if health is 0
        }
    }

    // Handle enemy death
    void Die()
    {
        // You can add an explosion effect or some death animation here
        EnemyManager.instance.enemiesKilled++;
        EnemyManager.instance.enemySpawned = false;
        Destroy(gameObject);  // Destroy the enemy object when it dies
    }
}
