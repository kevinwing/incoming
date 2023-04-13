using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LevelSpawner : MonoBehaviour
{
    private ObjectPool<GameObject> enemyPool;

    private GameObject[] spawnPoints;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject ballPrefab;

    // Enemy prefabs
    [SerializeField] private GameObject enemyPrefab1;
    // [SerializeField] private GameObject enemyPrefab2;
    // [SerializeField] private GameObject enemyPrefab3;

    private void Start()
    {
        // playerPickupBall = GameObject.Find("Player").GetComponent<PlayerPickupBall>();
        spawnPoints = GameObject.FindGameObjectsWithTag("spawn_point"); // get array of spawn points
    }
}