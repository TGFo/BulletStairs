using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health = 3;
    public float fireRate;
    public BulletSpawner spawner;
    public Weapon currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        spawner.currentWeapon = currentWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        spawner.timer += Time.deltaTime;
        if (spawner.timer >= spawner.firingRate)
        {
            spawner.timer = 0;
            if (Input.GetMouseButton(0))
            {
                spawner.Fire();
            }
        }
    }
}
