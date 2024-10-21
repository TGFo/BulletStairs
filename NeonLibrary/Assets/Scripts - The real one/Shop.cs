using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyFood()
    {
        if(ResourceManager.instance.globalCash >= 3)
        {
            ResourceManager.instance.globalCash -= 3;
            ResourceManager.instance.globalFood++;
        }
    }
    public void BuyWater()
    {
        if (ResourceManager.instance.globalCash >= 3)
        {
            ResourceManager.instance.globalCash -= 3;
            ResourceManager.instance.globalWater++;
        }
    }
    public void BuyShotgun()
    {
        if (ResourceManager.instance.globalCash >= 50)
        {
            ResourceManager.instance.globalCash -= 50;
            ResourceManager.instance.shotgunUnlocked = true;
        }
    }
}
