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
            if(weapon != null)
            {
                PlayerManager.instance.PickUpWeapon(weapon);
            }
            PlayerManager.instance.PickUpItems(food, water, cash);
            Destroy(gameObject);
        }
    }
}
