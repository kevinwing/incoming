using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnerBase : MonoBehaviour
{
    protected GameObject[] spawnPoints;
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] protected GameObject playerPrefab;
    [SerializeField] protected GameObject bossPrefab;
    [SerializeField] protected GameObject ballPrefab;


    protected int spawnPerPoint; // number of enemies to spawn at each spawn point at start
    protected int numEnemies; // spawnPerPoint * number of spawn points
    protected int numWaves;

    // Enemy prefabs
    [SerializeField] protected GameObject[] enemyPrefabs;
    // [SerializeField] private GameObject enemyPrefab2;
    // [SerializeField] private GameObject enemyPrefab3;

    /// <summary>
    /// Return Array of spawn points
    /// </summary>
    /// <param name="tag">string name of spawn point tag</param>
    /// <returns>GameObject[] of spawnpoint objects</returns>
    protected virtual GameObject[] GetSpawnPoints(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag); // get array of spawn points
    }

    /// <summary>
    /// Return size of wave to spawn
    /// </summary>
    /// <returns>integer representing number of enemies</returns>
    protected virtual int CalculateWave()
    {
        return numEnemies;
    }

    protected virtual Vector3[] GetSpawnPositions()
    {
        Vector3[] tempPosArr = new Vector3[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            tempPosArr[i] = spawnPoints[i].transform.position;
        }
        return tempPosArr;
    }

    protected virtual void SpawnWave()
    {
        Vector3[] spawnPositions = GetSpawnPositions();
        // int waveSize = CalculateWave();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject[] pointWave = new GameObject[spawnPerPoint];
            for (int j = 0; j < spawnPerPoint; j++)
            {
                pointWave[j] = enemyPool.GetEnemy(spawnPositions[j]);
            }
        }
    }
}
