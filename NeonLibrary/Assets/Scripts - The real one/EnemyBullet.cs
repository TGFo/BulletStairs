using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
     // How long the bullet lasts before being destroyed

    void Start()
    {
        
        Destroy(gameObject,10);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the bullet hits the player or any object with health
        if (collision.gameObject.CompareTag("Player"))
        {
            
            
                PlayerManager.instance.playerStats.health--;  // Deal damage to the player
            
            Destroy(gameObject);  // Destroy the bullet on impact
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);  // Destroy the bullet when it hits a wall
        }
    }
}
