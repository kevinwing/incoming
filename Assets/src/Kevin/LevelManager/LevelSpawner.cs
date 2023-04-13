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

    private int _spawnPerPoint = 1; // number of enemies to spawn at each spawn point

    // Enemy prefabs
    [SerializeField] private GameObject enemyPrefab1;
    // [SerializeField] private GameObject enemyPrefab2;
    // [SerializeField] private GameObject enemyPrefab3;

    private void Start()
    {
        // playerPickupBall = GameObject.Find("Player").GetComponent<PlayerPickupBall>();
        spawnPoints = GameObject.FindGameObjectsWithTag("spawn_point"); // get array of spawn points
        this.enemyPool = new ObjectPool<GameObject>(() => {
            return Instantiate(enemyPrefab1);
        }, enemy => {
            enemy.gameObject.SetActive(true);
        }, enemy => {
            enemy.gameObject.SetActive(false);
        }, enemy => {
            Destroy(enemy.gameObject);
        }, false, 20, 100);

        // InvokeRepeating();
    }
}