using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int playerFood;
    public int playerWater;
    public int playerCash;
    public PlayerStats playerStats;
    public List<Weapon> HeldWeapons = new List<Weapon>();
    public static PlayerManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerFood = ResourceManager.instance.carriedFood;
        playerWater = ResourceManager.instance.carriedWater;
        HeldWeapons.Add(ResourceManager.instance.carriedWeapon);
        playerStats.currentWeapon = ResourceManager.instance.carriedWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Extract()
    {
        ResourceManager.instance.globalFood += playerFood;
        ResourceManager.instance.globalWater += playerWater;
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
    public void PickUpWeapon(Weapon weapon)
    {
        HeldWeapons.Add(weapon);
    }
    public void PickUpItems(int food, int water, int cash)
    {
        playerFood += food;
        playerWater += water;
        playerCash += cash;
    }
}
