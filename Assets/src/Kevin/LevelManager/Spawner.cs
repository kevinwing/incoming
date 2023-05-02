using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawn enemies in waves
/// </summary>
public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // reference to the enemy prefab

    public EnemyPool enemyPool; // reference to the enemy pool

    private int enemyWaveSize; // number of enemies per wave
    // public float spawnDelay = 1f; // delay between enemy spawns
    // private int numActiveEnemies = 0; // number of active enemies

    private int numEnemiesSpawned = 0; // number of enemies spawned

    // public int NumEnemiesSpawned {
    //     get { return numEnemiesSpawned; }
    //     set { numEnemiesSpawned = value; }
    // }

    // public int WaveSize {
    //     get { return waveSize; }
    //     set { waveSize = value; }
    // }

    /// <summary>
    /// Start is called before the first frame update. This is where we initialize the spawner and start the first wave of the game level
    /// </summary>
    // private void Start()
    // {
    //     // initialize the spawner and start the first wave of the game level
    //     // enemyPool = new EnemyPool(enemyPrefab, WaveSize);
    //     StartNewGame();
    // }

    /// <summary>
    /// Start a new game by starting the first wave of the game level
    /// </summary>
    // public virtual void StartNewGame()
    // {
    //     NumEnemiesSpawned = 0; // reset the number of enemies spawned
    //     StartNewLevel(); // start the first wave of the game level
    // }

    // public virtual void Init(ref EnemyPool enemyPool)
    // {
    //     this.enemyPool = enemyPool;
    // }

    /// <summary>
    /// Start a new wave of enemies
    // /// </summary>
    public virtual void StartNewLevel(int waveSize = 1)
    {
        this.enemyWaveSize = waveSize;
        // this.numEnemiesSpawned = 0; // reset the number of enemies spawned
    }

    /// <summary>
    /// Spawn a wave of enemies
    /// </summary>
    public virtual List<GameObject> SpawnWave(int waveSize)
    {
        return SpawnEnemies(waveSize); // get a wave of enemies
    }

    // Method to get enemies from pool and return them as a list
    protected List<GameObject> SpawnEnemies(int numEnemies)
    {
        List<GameObject> activeEnemies = new List<GameObject>(numEnemies); // array of active enemies

        // loop through the number of enemies per wave and spawn an enemy
        for (int i = 0; i < numEnemies; i++)
        {
            activeEnemies.Add(SpawnEnemy()); // add the enemy to the array of active enemies
        }

        return activeEnemies; // return the array of active enemies
    }

    public virtual GameObject SpawnEnemy()
    {
        GameObject enemy = enemyPool.GetEnemyFromPool(this.transform.position, Quaternion.identity);

        // set the enemy's position to the spawner's position
        enemy.transform.position = this.transform.position;

        // increment the number of enemies spawned by 1
        this.numEnemiesSpawned++;

        return enemy;
    }


    /// <summary>
    /// Spawn a wave of enemies in a coroutine
    /// </summary>
    /// <returns></returns>
    // private void SpawnEnemies()
    // {

    // }

    /// <summary>
    /// Handle the enemy being defeated by returning the enemy to the enemy pool
    /// </summary>
    /// <param name="enemy">GameObject of the enemy from the EnemyPool</param>
    // public virtual void EnemyDefeated(GameObject enemy)
    // {
    //     enemyPool.ReturnEnemyToPool(enemy); // return the enemy to the enemy pool
    // }

    /// <summary>
    /// Check if the current wave is complete or not by checking if the number
    /// of enemies spawned is equal to the number of enemies per wave and if
    /// the number of active enemies is equal to 0 or not and return the result of the check as a bool value
    /// </summary>
    /// <returns>bool</returns>
    public virtual bool IsWaveSpawnComplete()
    {
        return this.numEnemiesSpawned >= this.enemyWaveSize;
    }



    /// <summary>
    /// Set the number of enemies per wave
    /// </summary>
    /// <param name="size">int</param>
    // public void SetWaveSize(int size)
    // {
    //     waveSize = size;
    // }

    // get wave size
    // public int GetWaveSize()
    // {
    //     return waveSize;
    // }

    /// <summary>
    /// End the current level by stopping all coroutines
    // /// </summary>
    // public void EndLevel()
    // {
    //     StopAllCoroutines();
    // }
}

