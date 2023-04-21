using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the spawning of enemies and bosses in the game level
/// </summary>
public class SpawnManager : MonoBehaviour
{
    public List<Spawner> enemySpawners; // list of enemy spawners
    public BossSpawner bossSpawner; // reference to the boss spawner
    public int numWaves = 5; // number of waves in the level
    public int numEnemiesPerWave = 1; // number of enemies per wave
    public int numBossesPerWave = 1; // number of bosses per wave
    private int currentWave = 1; // current wave
    private bool isBossWave = false; // flag to check if the current wave is a boss wave

    /// <summary>
    /// Start is called before the first frame update. This is where we initialize the spawners and start the first wave of the game level
    /// </summary>
    private void Start()
    {
        // initialize the spawners and start the first wave of the game level
        foreach (Spawner spawner in enemySpawners)
        {
            spawner.numEnemiesPerWave = numEnemiesPerWave;
            spawner.StartNewGame();
        }
        bossSpawner.numEnemiesPerWave = 0; // set the number of enemies per wave for the boss spawner
        bossSpawner.numBossesPerWave = numBossesPerWave;    // set the number of bosses per wave for the boss spawner
    }

    /// <summary>
    /// Update is called once per frame. This is where we check if the current wave is complete and start the next wave
    /// </summary>
    private void Update()
    {
        // check if the current wave is complete and start the next wave if it is complete and the level is not complete yet
        if (currentWave <= numWaves)
        {
            // check if the current wave is a boss wave or not and start the next wave if the current wave is complete and the level is not complete yet
            if (!isBossWave)
            {
                bool allWavesComplete = true; // flag to check if all the waves are complete

                // loop through all the enemy spawners and check if all the waves are complete
                foreach (Spawner spawner in enemySpawners)
                {
                    // check if the current wave is complete and set the flag to false if it is not complete and break out of the loop if the current wave is not complete and the level is not complete yet
                    if (!spawner.IsWaveComplete())
                    {
                        allWavesComplete = false; // set the flag to false
                        break;
                    }
                }

                // start the next wave if all the waves are complete and the level is not complete yet and increment the current wave by 1 if all the waves are complete and the level is not complete yet
                if (allWavesComplete)
                {
                    // start the next wave and increment the current wave by 1
                    foreach (Spawner spawner in enemySpawners)
                    {
                        spawner.StartNewGame();
                    }
                    currentWave++;
                }
            }
            else // start the next wave if the current wave is complete and the level is not complete yet and increment the current wave by 1 if the current wave is complete and the level is not complete yet
            {
                // start the next wave and increment the current wave by 1 if the current wave is complete and the level is not complete yet
                if (bossSpawner.IsWaveComplete())
                {
                    // start the next wave and increment the current wave by 1
                    bossSpawner.StartNewGame();
                    currentWave++;
                }
            }
            isBossWave = (currentWave % (numWaves + 1) == 0); // set the flag to true if the current wave is a boss wave and false if the current wave is not a boss wave
        }
        else // print a message to the console if the level is complete
        {
            Debug.Log("Level Complete!");
            enabled = false; // disable the script
        }
    }
}
