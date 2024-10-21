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
    public GameObject[] camChanges = new GameObject[5];
    public GameObject[] roomClosed = new GameObject[5];
    public GameObject[] roomOpen = new GameObject[5];
    
    public GameObject mainCamera;
    public Camera camera;



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
        Time.timeScale = 1;
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
        ResourceManager.instance.globalCash += playerCash;
        ResourceManager.instance.AvailableWeapons.AddRange(HeldWeapons);
        ResourceManager.instance.NextDay();

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
