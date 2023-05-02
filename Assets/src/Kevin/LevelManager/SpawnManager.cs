using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the spawning of enemies and bosses in the game level
/// </summary>
public class SpawnManager : MonoBehaviour
{
    public List<Spawner> enemySpawners; // list of enemy spawners
    public List<BossSpawner> bossSpawners; // reference to the boss spawner

    public GameObject selfObject; // reference to the self object

    private EnemyPool enemyPool; // reference to the enemy pool

    public GameObject enemyPrefab; // reference to the enemy prefab

    private List<GameObject> activeEnemies; // list of active enemies
    private List<GameObject> activeBosses; // list of active bosses
    private List<GameObject> defeatedEnemies; // list of defeated enemies
    public int numWaves = 5; // number of waves in the level
    public int numEnemiesPerWave = 1; // number of enemies per wave
    public int numBossesPerWave = 1; // number of bosses per wave
    private int currentWave = 1; // current wave
    private bool isBossWave = false; // flag to check if the current wave is a boss wave
    private bool isLevelEnded = false; // flag to check if the level has ended

    public bool IsLevelEnded
    {
        get { return isLevelEnded; }
    }

    private void Awake()
    {
        this.enemyPool = selfObject.GetComponent<EnemyPool>();
        this.activeEnemies = new List<GameObject>();
    }

    /// <summary>
    /// Start is called before the first frame update. This is where we initialize the spawners and start the first wave of the game level
    /// </summary>
    private void Start()
    {
        // initialize the spawners and start the first wave of the game level
        foreach (Spawner spawner in enemySpawners)
        {
            // spawner.Init(ref this.enemyPool);
        }

        foreach (BossSpawner bossSpawner in bossSpawners)
        {
            // bossSpawner.Init(ref this.enemyPool);
        }
    }

    /// <summary>
    /// Update is called once per frame. This is where we check if the current wave is complete and start the next wave
    /// </summary>
    private void Update()
    {
        // enemy wave
        if (currentWave <= numWaves) // check if the current wave is complete
        {
            // check if there are active enemies
            if (activeEnemies.Count == 0) // wave ended
            {
                // start next wave
                foreach (Spawner spawner in enemySpawners)
                {
                    // Add wave to active enemies for tracking
                    activeEnemies.AddRange(spawner.SpawnWave(numEnemiesPerWave));
                }

                currentWave++; // increment the current wave
                // check if the current wave is the last wave
                if (currentWave > numWaves)
                {
                    isBossWave = true;
                }
            }
            else // wave not ended
            {
                // check if there are defeated enemies and return them to the pool
                foreach (GameObject enemy in activeEnemies)
                {
                    // check if the enemy is not active
                    if (!enemy.activeSelf)
                    {
                        enemyPool.ReturnEnemyToPool(enemy); // return the enemy to the pool
                        activeEnemies.Remove(enemy); // remove the enemy from the active enemies list
                    }
                }
            }

        }
        // boss wave
        else
        {
            if (!isLevelEnded)
            {
                // check if boss wave has been triggered
                if (isBossWave)
                {
                    if (activeBosses.Count == 0)
                    {
                        // reset boss wave flag
                        isBossWave = false;
                        // spawn boss wave
                        foreach (BossSpawner bossSpawner in bossSpawners)
                        {
                            // Add wave to active bosses for tracking
                            activeBosses.AddRange(bossSpawner.SpawnWave(numBossesPerWave));
                        }
                    }
                }
                else
                {
                    isLevelEnded = true;
                }
            }
        }
    }
}
