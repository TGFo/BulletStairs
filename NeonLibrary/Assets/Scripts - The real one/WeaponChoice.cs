using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChoice : MonoBehaviour
{
    public Weapon basicGun;
    public Weapon shotGun;
    public void BasicGun()
    {
        ResourceManager.instance.carriedWeapon = basicGun;
    }
    public void Shotgun()
    {
        ResourceManager.instance.carriedWeapon = shotGun;
    }
}
