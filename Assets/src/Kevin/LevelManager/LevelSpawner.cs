using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LevelSpawner : MonoBehaviour
{
    // private ObjectPool<GameObject> enemyPool;

    private GameObject[] spawnPoints;
    // [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject ballPrefab;

    private int spawnPerPoint = 1; // number of enemies to spawn at each spawn point at start
    private int numEnemies; // spawnPerPoint * number of spawn points
    private int numWaves;

    // Enemy prefabs
    [SerializeField] private GameObject enemyPrefab1;
    // [SerializeField] private GameObject enemyPrefab2;
    // [SerializeField] private GameObject enemyPrefab3;

    private void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("spawn_point"); // get array of spawn points
        numEnemies = spawnPerPoint * spawnPoints.Length;
        numWaves = 5;
    }

    private void Start()
    {

    }

    
}