using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // [SerializeField] protected EnemyPool enemyPool;
    [SerializeField] protected int waveSize;
    [SerializeField] protected GameObject enemyPrefab;

    protected List<GameObject> spawnedEnemies;
    protected bool waveEnded;
    // protected int remainingEnemies;

    public int WaveSize
    {
        get { return waveSize; }
        set { waveSize = value; }
    }

    protected virtual void Awake()
    {
        // enemyPool = this.gameObject.GetComponent<EnemyPool>();
        // enemyPool.PoolSize = waveSize * 2;
        spawnedEnemies = new List<GameObject>();
    }

    protected virtual void Start()
    {
        waveEnded = true;
        // remainingEnemies = 0;
    }

    public virtual void TriggerWave()
    {
        if (waveEnded)
        {
            waveEnded = false;
            SpawnEnemies();
        }
    }

    protected virtual void SpawnEnemies()
    {
        for (int i = 0; i < waveSize; i++)
        {
            GameObject enemy = EnemyPool.SharedInstance.GetEnemyFromPool();
            if (enemy != null)
            {
                enemy.transform.position = transform.position;
                enemy.transform.rotation = transform.rotation;
                enemy.SetActive(true);
                spawnedEnemies.Add(enemy);
                // remainingEnemies++;
            }
        }
    }

    // public void SetWaveSize(int newSize)
    // {
    //     waveSize = newSize;
    // }

    // public int GetWaveSize()
    // {
    //     return waveSize;
    // }

    public bool HasWaveEnded()
    {
        return waveEnded;
    }

    protected virtual void Update()
    {
        CheckWaveStatus();
    }

    // check if all enemies in the wave have been defeated

    protected void CheckWaveStatus()
    {
        if (spawnedEnemies.Count == 0)
        {
            waveEnded = true;
        }
        else
        {
            for (int i = 0; i < spawnedEnemies.Count; i++)
            {
                if (spawnedEnemies[i].activeInHierarchy == false)
                {
                    spawnedEnemies.RemoveAt(i);
                    // remainingEnemies--;
                }
            }
        }
    }
}
