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
        if (useWeaponForStats)
        {
            speed = currentWeapon.projectileSpeed;
            firingRate = currentWeapon.fireRate;
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
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            firedBullet = spawnedBullet.GetComponent<Bullet>();
            firedBullet.speed = speed;
            firedBullet.bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
            firedBullet.playerSpeed = rb.velocity;
            firedBullet.OnBulletFired();
        }
    }
}
