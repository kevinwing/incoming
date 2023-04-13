// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private Queue<GameObject> _enemyQueue; // instantiate a queue to hold enemies
    [SerializeField] private GameObject enemyPrefab; // reference of enemy prefab to clone
    [SerializeField] private int poolSize = 10; // default size of pool;

    private void Awake()
    {
        _enemyQueue = new Queue<GameObject>(); // create instance of queue.
    }

    private void Start()
    {
        AddEnemies(poolSize); // add initial number of enemies to pool
    }

    /// <summary>
    /// Takes in a vector3 for the postion and returns an active enemy at given
    /// coordinates
    /// </summary>
    /// <param name="position">Vector3 coordinates</param>
    /// <returns>An enemy GameObject</returns>
    public GameObject GetEnemy(Vector3 position)
    {
        if (_enemyQueue.Count == 0)
        {
            AddEnemies(1);
        }

        GameObject enemy = _enemyQueue.Dequeue();
        enemy.transform.position = position;
        enemy.SetActive(true);
        return enemy;
    }

    /// <summary>
    /// Add number of enemies as given by num
    /// </summary>
    /// <param name="num">number of enemies to add to pool</param>
    private void AddEnemies(int num)
    {
        GameObject enemy;
        for (int i = 0; i < num; i++)
        {
            enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            _enemyQueue.Enqueue(enemy);
        }
    }

    /// <summary>
    /// Deactivate enemy and return it to the pool for reuse
    /// </summary>
    /// <param name="enemy">An enemy GameObject to store in pool</param>
    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        _enemyQueue.Enqueue(enemy);
    }

    /// <summary>
    /// Set pool size
    /// </summary>
    /// <param name="size">integer of new size</param>
    public void SetSize(int size)
    {
        this.poolSize = size;
        while (_enemyQueue.Count < size)
        {
            AddEnemies(1);
        }
    }

    /// <summary>
    /// Return current pool size
    /// </summary>
    /// <returns>integer of current pool size</returns>
    public int GetSize()
    {
        return this.poolSize;
    }
}
