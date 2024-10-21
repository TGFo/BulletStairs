using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Reference to the enemy prefab
    public float spawnDelay = 3f;   // Delay in seconds before spawning an enemy
    
    void Start()
    {
        
        
    }
    public void Update()
    {
        if(EnemyManager.instance.enemySpawned==false)
        {
            switch (EnemyManager.instance.enemiesKilled)
            {
                case 0:
                    StartCoroutine(SpawnEnemyAfterDelay());
                    
                    break;
                case 1:
                    StartCoroutine(SpawnEnemyAfterDelay());
                    break;
                case 2:
                    StartCoroutine(SpawnEnemyAfterDelay());
                    break;
                case 3:
                    StartCoroutine(SpawnEnemyAfterDelay());
                    break;
                case 4:
                    StartCoroutine(SpawnEnemyAfterDelay());
                    break;
                default:
                    break;
            }
        }
        
        
    }
    
    IEnumerator SpawnEnemyAfterDelay()
    {
        EnemyManager.instance.enemySpawned = true;
        // Wait for the specified amount of time (3 seconds by default)
        yield return new WaitForSeconds(spawnDelay);

        switch (EnemyManager.instance.enemiesKilled)
        {
            case 0:
                Instantiate(enemyPrefab, EnemyManager.instance.enemySpawns[0].transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(enemyPrefab, EnemyManager.instance.enemySpawns[1].transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(enemyPrefab, EnemyManager.instance.enemySpawns[2].transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(enemyPrefab, EnemyManager.instance.enemySpawns[3].transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(enemyPrefab, EnemyManager.instance.enemySpawns[4].transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
        

    }
}
