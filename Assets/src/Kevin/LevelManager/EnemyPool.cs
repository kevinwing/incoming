// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private Queue<GameObject> enemyQueue; // instantiate a queue to hold enemies
    private GameObject enemyPrefab; // reference of enemy prefab to clone
    private int poolSize = 10; // default size of pool;

    public int numActiveEnemies;

    public EnemyPool(GameObject enemyPrefab, int poolSize = 10)
    {
        this.enemyQueue = new Queue<GameObject>(); // create instance of queue.
        this.enemyPrefab = enemyPrefab;
        this.poolSize = poolSize;
    }

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
        GameObject enemy = this.enemyQueue.Dequeue();

        // set enemy position
        enemy.transform.position = position;
        enemy.transform.rotation = rotation;

        // activate enemy
        enemy.SetActive(true);

        numActiveEnemies++;

        // return enemy
        return enemy;
    }

    /// <summary>
    /// Add number of enemies as given by num
    /// </summary>
    /// <param name="num">number of enemies to add to pool</param>
    private void AddEnemiesToPool(int num)
    {
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

        numActiveEnemies--;
    }

    private void DeleteEnemyFromPool(GameObject enemy)
    {
        // get enemy from pool
        GameObject enemyFromPool = this.enemyQueue.Dequeue();

        // delete enemy from pool
        Destroy(enemyFromPool);
    }

    /// <summary>
    /// Set pool size
    /// </summary>
    /// <param name="size">integer of new size</param>
    // set size of pool and shrink or grow pool accordingly
    public void SetSize(int size)
    {
        if (size > this.poolSize)
        {
            AddEnemiesToPool(size - this.poolSize);
        }
        else if (size < this.poolSize)
        {
            for (int i = 0; i < this.poolSize - size; i++)
            {
                DeleteEnemyFromPool(this.enemyQueue.Dequeue());
            }
        }
        this.poolSize = size;
    }

    /// <summary>
    /// Return current pool size
    /// </summary>
    /// <returns>integer of current pool size</returns>
    public int GetSize()
    {
        return this.poolSize;
    }

    // clear pool
    public void Clear()
    {
        for (int i = 0; i < this.poolSize; i++)
        {
            DeleteEnemyFromPool(this.enemyQueue.Dequeue());
        }
    }

    // return true if pool is empty
    public bool IsEmpty()
    {
        return this.enemyQueue.Count == 0;
    }

    // return number of active enemies
    public int GetNumActiveEnemies()
    {
        return numActiveEnemies;
    }
}
