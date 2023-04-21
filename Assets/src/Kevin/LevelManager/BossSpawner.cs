using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : Spawner
{
    public GameObject bossPrefab;
    public int numBossesPerWave = 1;
    public float bossSpawnDelay = 3f;

    private int numBossesSpawned = 0;

    public override void StartNewGame()
    {
        numBossesSpawned = 0;
        base.StartNewGame();
    }

    public override void StartNewLevel()
    {
        if (numBossesSpawned < numBossesPerWave)
        {
            StartCoroutine(SpawnBoss());
        }
        else
        {
            base.StartNewLevel();
        }
    }

    private IEnumerator SpawnBoss()
    {
        GameObject boss = Instantiate(bossPrefab, transform.position, Quaternion.identity);
        numBossesSpawned++;
        yield return new WaitForSeconds(bossSpawnDelay);
    }

    // check if the wave is complete
    public override bool IsWaveComplete()
    {
        return numBossesSpawned >= numBossesPerWave && base.IsWaveComplete();
    }
}