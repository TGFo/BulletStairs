using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Weapon")]
public class Weapon : ScriptableObject
{
    public string Name;
    public string description;
    public float fireRate;
    public float projectileSpeed;
    public float damage;
    public float value;
    public GameObject bulletSprite;
}
