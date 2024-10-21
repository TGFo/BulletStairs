// Bullet Spawner


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletSpawner : MonoBehaviour
{
    public Weapon currentWeapon;

    enum SpawnerType { Straight, Spin }
    public Rigidbody2D rb;
    public float speedMult = 10;
    public bool worldSpawner = true;
    public bool useWeaponForStats;
    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;
    public int damage = 1;


    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] public float firingRate = 1f;


    private GameObject spawnedBullet;
    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if(currentWeapon != null)
        { 
            if (useWeaponForStats)
            {
                speed = currentWeapon.projectileSpeed;
                firingRate = currentWeapon.fireRate;
                damage = currentWeapon.damage;
            }
        }
        if (!worldSpawner)return;
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }


    public void Fire()
    {
        Bullet firedBullet;
        if (ResourceManager.instance.carriedWeapon.name== "BasicGun")
        {
            
            if (bullet)
            {
                spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                firedBullet = spawnedBullet.GetComponent<Bullet>();
                firedBullet.speed = speed;
                firedBullet.bulletLife = bulletLife;
                firedBullet.damage = damage;
                spawnedBullet.transform.rotation = transform.rotation;
                firedBullet.playerSpeed = rb.velocity;
                firedBullet.OnBulletFired();
            }
        }
        else if(ResourceManager.instance.carriedWeapon.name == "Shotgun")
        {
            int numberOfBullets = 5;  // Number of bullets (pellets) in the shotgun blast
            float spreadAngle = 15f;  // Spread angle (in degrees)

            for (int i = 0; i < numberOfBullets; i++)
            {
                if (bullet)
                {
                    // Instantiate a bullet for each pellet in the shotgun blast
                    spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                    firedBullet = spawnedBullet.GetComponent<Bullet>();

                    // Calculate random spread
                    float angleOffset = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);

                    // Rotate the bullet by the spread angle
                    spawnedBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.eulerAngles.z + angleOffset));

                    // Assign the bullet's speed, life, and damage
                    firedBullet.speed = speed;
                    firedBullet.bulletLife = bulletLife;
                    firedBullet.damage = damage;

                    // Set the player's speed as bullet velocity factor
                    firedBullet.playerSpeed = rb.velocity;

                    // Trigger the bullet's firing logic
                    firedBullet.OnBulletFired();
                }
            }
        }
        
    }
}
