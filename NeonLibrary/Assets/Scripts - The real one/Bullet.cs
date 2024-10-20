// Bullet


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float bulletLife = 1f;  // Defines how long before the bullet is destroyed
    public float rotation = 0f;
    public float speed = 1f;
    public Rigidbody2D rb;
    public Vector2 playerSpeed;
    private Vector2 spawnPoint;
    private float timer = 0f;
    public int damage;
    


    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
        AudioManager.instance.AddSFXClip("Bullet", AudioManager.instance.audioClips[2]);
        AudioManager.instance.PlaySFX("Bullet", 0.1f, 1, false);



    }


    // Update is called once per frame
    void Update()
    {
        if (timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        //transform.position = Movement(timer);
    }


    private Vector2 Movement(float timer)
    {
        // Moves right according to the bullet's rotation
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }
    public void OnBulletFired()
    {
        if(playerSpeed.magnitude >= 13)rb.AddForce(speed * (Vector2)transform.right * playerSpeed.magnitude);
        else rb.AddForce(speed * (Vector2)transform.right * 10);
        Debug.Log(playerSpeed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the bullet hits the player or any object with health
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
            if(enemyStats != null)
            {
                enemyStats.TakeDamage(damage);
            }
            
            Destroy(gameObject);
            
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.TakeDamage(Mathf.FloorToInt(Mathf.FloorToInt(damage/2)));
            }

            Destroy(gameObject);

        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);  // Destroy the bullet when it hits a wall
        }
    }
}
