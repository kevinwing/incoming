using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : Spawner
{
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private int bossSpawnWave;

    private int currentWave;

    protected override void Start()
    {
        base.Start();
        currentWave = 0;
    }

    // public void SetBossPrefab(ref GameObject bossPrefab)
    // {
    //     this.bossPrefab = bossPrefab;
    // }

    public override void TriggerWave()
    {
        SpawnBoss();
    }

    private void SpawnBoss()
    {
        GameObject boss = Instantiate(this.bossPrefab, this.transform.position, this.transform.rotation);
        spawnedEnemies.Add(boss);
    }
}