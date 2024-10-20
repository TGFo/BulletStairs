using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int globalCash;
    public int globalFood;
    public int globalWater;
    public int carriedFood;
    public int carriedWater;
    public Weapon carriedWeapon;
    public List<Weapon> AvailableWeapons = new List<Weapon>();
    public static ResourceManager instance;
    public int daysPassed;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextDay()
    {
  
        globalFood -= 5;
        globalWater -= 5;
        globalCash -= 5;
        daysPassed++;
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
