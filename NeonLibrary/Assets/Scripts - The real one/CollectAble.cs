using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAble : MonoBehaviour
{
    [SerializeField] int food;
    [SerializeField] int water;
    [SerializeField] int cash;
    [SerializeField] Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(EnemyManager.instance.enemiesKilled == 5)
            {
                cash = Random.Range(4, 7);
                water = Random.Range(4, 7);
                food = Random.Range(4, 7);
            }
            else
            {
                cash = Random.Range(1, 4);
                water = Random.Range(1, 4);
                food = Random.Range(1, 4);
            }
            

            if (weapon != null)
            {
                PlayerManager.instance.PickUpWeapon(weapon);
            }
            PlayerManager.instance.PickUpItems(food, water, cash);
            Destroy(gameObject);
        }
    }
}
