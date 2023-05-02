using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Boss spawner that spawns a boss at the end of each level
/// </summary>
public class BossSpawner : Spawner
{
    public GameObject bossPrefab; // reference to the boss prefab
    private int numBossesPerWave; // number of bosses per wave
    // public float bossSpawnDelay = 3f; // delay between each boss spawn

    private int numBossesSpawned = 0; // number of bosses spawned

    /// <summary>
    /// Start a new level by spawning a boss if the number of bosses spawned is less than the number of bosses per wave
    /// </summary>
    public override void StartNewLevel(int waveSize = 1)
    {
        numBossesPerWave = waveSize;
        numBossesSpawned = 0; // reset the number of bosses spawned
    }

    public override GameObject SpawnEnemy()
    {
        GameObject boss = Instantiate(this.bossPrefab, this.transform.position, Quaternion.identity); // instantiate a boss at the spawner's position
        this.numBossesSpawned++; // increment the number of bosses spawned
        return boss;
    }

    /// <summary>
    /// Check if the current wave is complete or not by checking if the number of bosses spawned is equal to the number of bosses per wave and if the base wave is complete or not and return the result of the check as a bool value
    /// </summary>
    /// <returns>bool</returns>
    public override bool IsWaveSpawnComplete()
    {
        // check if the number of bosses spawned is equal to the number of bosses per wave and if the base wave is complete or not and return the result of the check as a bool value
        return numBossesSpawned >= numBossesPerWave;
    }
}