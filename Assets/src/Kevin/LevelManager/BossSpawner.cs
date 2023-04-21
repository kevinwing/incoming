using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Boss spawner that spawns a boss at the end of each level
/// </summary>
public class BossSpawner : Spawner
{
    public GameObject bossPrefab; // reference to the boss prefab
    public int numBossesPerWave = 1; // number of bosses per wave
    public float bossSpawnDelay = 3f; // delay between each boss spawn

    private int numBossesSpawned = 0; // number of bosses spawned

    /// <summary>
    /// Start a new game by setting the number of bosses spawned to 0 and starting the first wave of the game level
    /// </summary>
    public override void StartNewGame()
    {
        numBossesSpawned = 0; // reset the number of bosses spawned
        base.StartNewGame(); // start the first wave of the game level
    }

    /// <summary>
    /// Start a new level by spawning a boss if the number of bosses spawned is less than the number of bosses per wave
    /// </summary>
    public override void StartNewLevel()
    {
        // spawn a boss if the number of bosses spawned is less than the number of bosses per wave
        if (numBossesSpawned < numBossesPerWave)
        {
            StartCoroutine(SpawnBoss()); // spawn a boss in a coroutine
        }
        else
        {
            base.StartNewLevel(); // start a new wave of enemies
        }
    }

    /// <summary>
    /// Spawn a boss in a coroutine and increment the number of bosses spawned
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator SpawnBoss()
    {
        GameObject boss = Instantiate(bossPrefab, transform.position, Quaternion.identity); // spawn a boss
        numBossesSpawned++; // increment the number of bosses spawned by 1
        yield return new WaitForSeconds(bossSpawnDelay); // wait for the boss spawn delay before spawning the next boss
    }

    /// <summary>
    /// Check if the current wave is complete or not by checking if the number of bosses spawned is equal to the number of bosses per wave and if the base wave is complete or not and return the result of the check as a bool value
    /// </summary>
    /// <returns>bool</returns>
    public override bool IsWaveComplete()
    {
        // check if the number of bosses spawned is equal to the number of bosses per wave and if the base wave is complete or not and return the result of the check as a bool value
        return numBossesSpawned >= numBossesPerWave && base.IsWaveComplete();
    }
}