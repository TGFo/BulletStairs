using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
        public int enemiesKilled;
        public bool enemySpawned;
        public static EnemyManager instance;
    public GameObject[] enemySpawns = new GameObject[5];
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
    
}
