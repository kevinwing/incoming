// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// /// <summary>
// /// Spawn enemies in waves
// /// </summary>
// public class SpawnerCopy : MonoBehaviour
// {
//     public GameObject enemyPrefab; // reference to the enemy prefab
//     public int numEnemiesPerWave = 5; // number of enemies per wave
//     public float spawnDelay = 1f; // delay between enemy spawns

//     private EnemyPool enemyPool; // reference to the enemy pool
//     private int numEnemiesSpawned = 0; // number of enemies spawned

//     /// <summary>
//     /// Start is called before the first frame update. This is where we initialize the spawner and start the first wave of the game level
//     /// </summary>
//     private void Start()
//     {
//         // initialize the spawner and start the first wave of the game level
//         enemyPool = new EnemyPool(enemyPrefab, numEnemiesPerWave);
//         StartNewGame();
//     }

//     /// <summary>
//     /// Start a new game by starting the first wave of the game level
//     /// </summary>
//     public virtual void StartNewGame()
//     {
//         numEnemiesSpawned = 0; // reset the number of enemies spawned
//         StartNewLevel(); // start the first wave of the game level
//     }

//     /// <summary>
//     /// Start a new wave of enemies
//     /// </summary>
//     public virtual void StartNewLevel()
//     {
//         SpawnWave();
//     }

//     /// <summary>
//     /// Check if the current wave is complete or not by checking if the number
//     /// of enemies spawned is equal to the number of enemies per wave and if
//     /// the number of active enemies is equal to 0 or not and return the result of the check as a bool value
//     /// </summary>
//     /// <returns>bool</returns>
//     public virtual bool IsWaveComplete()
//     {
//         return numEnemiesSpawned >= numEnemiesPerWave && enemyPool.GetNumActiveEnemies() == 0;
//     }

//     /// <summary>
//     /// Spawn a wave of enemies in a coroutine
//     /// </summary>
//     /// <returns></returns>
//     private IEnumerator SpawnEnemies()
//     {
//         // loop through the number of enemies per wave and spawn an enemy
//         for (int i = 0; i < numEnemiesPerWave; i++)
//         {
//             // spawn an enemy and increment the number of enemies spawned by 1 and wait for the spawn delay before spawning the next enemy in the wave of enemies
//             GameObject enemy = enemyPool.GetEnemyFromPool(transform.position, Quaternion.identity);

//             // set the enemy's position to the spawner's position
//             enemy.transform.position = transform.position;

//             // increment the number of enemies spawned by 1
//             numEnemiesSpawned++;

//             // wait for the spawn delay before spawning the next enemy in the wave of enemies
//             yield return new WaitForSeconds(spawnDelay);
//         }
//     }

//     /// <summary>
//     /// Handle the enemy being defeated by returning the enemy to the enemy pool
//     /// </summary>
//     /// <param name="enemy">GameObject of the enemy from the EnemyPool</param>
//     public void EnemyDefeated(GameObject enemy)
//     {
//         enemyPool.ReturnEnemyToPool(enemy); // return the enemy to the enemy pool
//     }

//     /// <summary>
//     /// Spawn a wave of enemies
//     /// </summary>
//     public void SpawnWave()
//     {
//         StartCoroutine(SpawnEnemies()); // spawn a wave of enemies in a coroutine
//     }

//     /// <summary>
//     /// End the current level by stopping all coroutines
//     /// </summary>
//     public void EndLevel()
//     {
//         StopAllCoroutines();
//     }
// }

