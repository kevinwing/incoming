// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Pool;

public class LevelSpawner : LevelSpawnerBase
{
    private string spawnTag = "spawn_point";

    private void Awake()
    {
        // Instantiate(playerPrefab, new Vector3(0,0,0), new Quaternion());
    }

    private void Start()
    {
        spawnPoints = GetSpawnPoints(spawnTag);
        numEnemies = spawnPerPoint * spawnPoints.Length;
        SpawnWave();
    }

    /// <summary>
    /// Calculates wave based on number of points and spawns per point
    /// </summary>
    /// <returns>integer</returns>
    protected override int CalculateWave()
    {
        return spawnPoints.Length * spawnPerPoint;
    }
}