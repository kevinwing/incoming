using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numEnemiesPerWave = 10;
    public float spawnDelay = 1f;

    private EnemyPool enemyPool;
    private int numEnemiesSpawned = 0;

    private void Start()
    {
        enemyPool = new EnemyPool(enemyPrefab, numEnemiesPerWave);
        StartNewGame();
    }

    public virtual void StartNewGame()
    {
        numEnemiesSpawned = 0;
        StartNewLevel();
    }

    public virtual void StartNewLevel()
    {
        SpawnWave();
    }

    public virtual bool IsWaveComplete()
    {
        return numEnemiesSpawned >= numEnemiesPerWave && enemyPool.GetNumActiveEnemies() == 0;
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numEnemiesPerWave; i++)
        {
            GameObject enemy = enemyPool.GetEnemyFromPool(transform.position, Quaternion.identity);
            enemy.transform.position = transform.position;
            numEnemiesSpawned++;
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    // This method is called by the SpawnManger when an enemy is defeated
    public void EnemyDefeated(GameObject enemy)
    {
        enemyPool.ReturnEnemyToPool(enemy);
    }

    // spawn a wave of enemies
    public void SpawnWave()
    {
        StartCoroutine(SpawnEnemies());
    }

    // end the level
    public void EndLevel()
    {
        StopAllCoroutines();
    }
}

