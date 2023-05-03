using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<Spawner> spawners;
    [SerializeField] private BossSpawner bossSpawner;
    // [SerializeField] private EnemyPool enemyPool;
    // [SerializeField] private GameObject enemyPrefab;
    // [SerializeField] private GameObject bossPrefab;
    [SerializeField] private int numberOfWaves = 3;
    [SerializeField] private int waveSize = 1;
    [SerializeField] private int bossWaveSize = 1;

    private int currentWave;
    private int poolSize;
    private bool isBossWave;


    // private void Awake()
    // {
    //     // bossSpawner.SetEnemyPool(enemyPool);
    // }

    private void Start()
    {
        isBossWave = false;
        currentWave = 0;
        waveSize = 1;
        poolSize = waveSize * 2;

        foreach (Spawner spawner in spawners)
        {
            spawner.WaveSize = this.waveSize;
            // Debug.Log("Wave size: " + spawner.WaveSize);
        }
        bossSpawner.WaveSize = this.bossWaveSize;
        // Debug.Log("Boss wave size: " + bossSpawner.WaveSize);
    }

    private void Update()
    {
        if (!isBossWave && currentWave < numberOfWaves && CheckAllWavesEnded())
        {
            currentWave++;
            TriggerNextWave();
        }
        else if (currentWave == numberOfWaves && CheckAllWavesEnded())
        {
            isBossWave = true;
            bossSpawner.TriggerWave();
            numberOfWaves++; // Increment the numberOfWaves to avoid multiple boss spawns
        }
    }

    private bool CheckAllWavesEnded()
    {
        foreach (Spawner spawner in spawners)
        {
            if (!spawner.HasWaveEnded())
            {
                return false;
            }
        }
        return true;
    }

    private void TriggerNextWave()
    {
        foreach (Spawner spawner in spawners)
        {
            spawner.TriggerWave();
        }
    }
}
