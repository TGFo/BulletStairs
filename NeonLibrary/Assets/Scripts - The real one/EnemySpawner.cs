using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Reference to the enemy prefab
    void Start()
    {
        // Instantiate an instance of the enemy at a certain position and rotation
        GameObject enemyInstance = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
