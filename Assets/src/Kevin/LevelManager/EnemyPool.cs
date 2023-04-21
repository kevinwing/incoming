// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private Queue<GameObject> enemyQueue; // instantiate a queue to hold enemies
    private GameObject enemyPrefab; // reference of enemy prefab to clone
    private int poolSize = 10; // default size of pool;

    public int numActiveEnemies;

    /// <summary>
    /// Constructor for EnemyPool class
    /// </summary>
    /// <param name="enemyPrefab">Prefab instance being cloned and stored in pool</param>
    /// <param name="poolSize">size of pool of enemies to initialize</param>
    public EnemyPool(GameObject enemyPrefab, int poolSize = 10)
    {
        this.enemyQueue = new Queue<GameObject>(); // create instance of queue.
        this.enemyPrefab = enemyPrefab;
        this.poolSize = poolSize;
    }

    /// <summary>
    /// Add intial enemies to pool
    /// </summary>
    void Awake()
    {
        // add intial enemies to pool
        AddEnemiesToPool(this.poolSize);
    }


    /// <summary>
    /// Takes in a vector3 for the postion and returns an active enemy at given
    /// coordinates
    /// </summary>
    /// <param name="position">Vector3 coordinates</param>
    /// <returns>An enemy GameObject</returns>
    public GameObject GetEnemyFromPool(Vector3 position, Quaternion rotation)
    {
        // get enemy from pool
        GameObject enemy = this.enemyQueue.Dequeue(); // get enemy from pool

        // set enemy position
        enemy.transform.position = position; // set enemy position
        enemy.transform.rotation = rotation; // set enemy rotation

        // activate enemy
        enemy.SetActive(true); // activate enemy

        numActiveEnemies++; // increment number of active enemies

        // return enemy
        return enemy; // return enemy to caller
    }

    /// <summary>
    /// Add number of enemies as given by num
    /// </summary>
    /// <param name="num">number of enemies to add to pool</param>
    private void AddEnemiesToPool(int num)
    {
        // add enemies to pool as given by num parameter
        for (int i = 0; i < num; i++)
        {
            // create enemy
            GameObject enemy = Instantiate(this.enemyPrefab);

            // deactivate enemy
            enemy.SetActive(false);

            // add enemy to pool
            this.enemyQueue.Enqueue(enemy);
        }
    }

    /// <summary>
    /// Deactivate enemy and return it to the pool for reuse
    /// </summary>
    /// <param name="enemy">An enemy GameObject to store in pool</param>
    public void ReturnEnemyToPool(GameObject enemy)
    {
        // deactivate enemy
        enemy.SetActive(false);

        // return enemy to pool
        this.enemyQueue.Enqueue(enemy);

        // decrement number of active enemies
        numActiveEnemies--;
    }

    /// <summary>
    /// Delete enemy from pool and destroy it from scene
    /// </summary>
    /// <param name="enemy">Enemy Object to be deleted</param>
    private void DeleteEnemyFromPool(GameObject enemy)
    {
        // delete enemy from pool
        Destroy(enemy);
    }

    /// <summary>
    /// Set pool size
    /// </summary>
    /// <param name="size">integer of new size</param>
    // set size of pool and shrink or grow pool accordingly
    public void SetSize(int size)
    {
        // if size is greater than current pool size, add enemies to pool
        if (size > this.poolSize)
        {
            AddEnemiesToPool(size - this.poolSize); // add enemies to pool
        }
        // if size is less than current pool size, delete enemies from pool
        else if (size < this.poolSize)
        {
            // delete enemies from pool as given by size parameter and current pool size difference
            for (int i = 0; i < this.poolSize - size; i++)
            {
                DeleteEnemyFromPool(this.enemyQueue.Dequeue()); // delete enemy from pool
            }
        }
        this.poolSize = size; // set pool size
    }

    /// <summary>
    /// Return current pool size
    /// </summary>
    /// <returns>integer of current pool size</returns>
    public int GetSize()
    {
        return this.poolSize; // return pool size
    }

    /// <summary>
    /// Clear pool of all enemies and delete them from scene
    /// </summary>
    public void Clear()
    {
        // delete all enemies from pool
        for (int i = 0; i < this.poolSize; i++)
        {
            DeleteEnemyFromPool(this.enemyQueue.Dequeue()); // delete enemy from pool
        }
    }

    /// <summary>
    /// Check if pool is empty
    /// </summary>
    /// <returns>bool</returns>
    public bool IsEmpty()
    {
        return this.enemyQueue.Count == 0; // return true if pool is empty and false otherwise
    }

    /// <summary>
    /// Get number of active enemies in pool
    /// </summary>
    /// <returns></returns>
    public int GetNumActiveEnemies()
    {
        return numActiveEnemies; // return number of active enemies
    }
}
