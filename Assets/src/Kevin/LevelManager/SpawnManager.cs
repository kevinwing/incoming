using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Spawner> enemySpawners;
    public BossSpawner bossSpawner;
    public int numWaves = 5;
    public int numEnemiesPerWave = 1;
    public int numBossesPerWave = 1;
    private int currentWave = 1;
    private bool isBossWave = false;

    private void Start()
    {
        foreach (Spawner spawner in enemySpawners)
        {
            spawner.numEnemiesPerWave = numEnemiesPerWave;
            spawner.StartNewGame();
        }
        bossSpawner.numEnemiesPerWave = numEnemiesPerWave;
        bossSpawner.numBossesPerWave = numBossesPerWave;
    }

    private void Update()
    {
        if (currentWave <= numWaves)
        {
            if (!isBossWave)
            {
                bool allWavesComplete = true;
                foreach (Spawner spawner in enemySpawners)
                {
                    if (!spawner.IsWaveComplete())
                    {
                        allWavesComplete = false;
                        break;
                    }
                }
                if (allWavesComplete)
                {
                    foreach (Spawner spawner in enemySpawners)
                    {
                        spawner.StartNewGame();
                    }
                    currentWave++;
                }
            }
            else
            {
                if (bossSpawner.IsWaveComplete())
                {
                    bossSpawner.StartNewGame();
                    currentWave++;
                }
            }
            isBossWave = (currentWave % (numWaves + 1) == 0);
        }
        else
        {
            Debug.Log("Level Complete!");
            enabled = false;
        }
    }
}
