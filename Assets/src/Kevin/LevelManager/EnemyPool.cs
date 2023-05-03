// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool SharedInstance;
    public List<GameObject> enemies;
    public GameObject enemyPrefab;
    public int poolSize = 20;

    public int PoolSize
    {
        get { return poolSize; }
        set {
            poolSize = value;
            Resize();
        }
    }

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        enemies = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < poolSize; i++)
        {
            tmp = Instantiate(enemyPrefab);
            tmp.SetActive(false);
            enemies.Add(tmp);
        }
    }

    public GameObject GetEnemyFromPool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            if(!enemies[i].activeInHierarchy)
            {
                return enemies[i];
            }
        }
        return null;
    }

    private void Resize()
    {
        if (poolSize < 0)
        {
            poolSize = 0;
            return;
        }

        GameObject tmp;

        if (poolSize > enemies.Count)
        {
            for (int i = 0; i < poolSize - enemies.Count; i++)
            {
                tmp = Instantiate(enemyPrefab);
                tmp.SetActive(false);
                enemies.Add(tmp);
            }
        }
        else if (poolSize < enemies.Count)
        {
            for (int i = 0; i < enemies.Count - poolSize; i++)
            {
                tmp = enemies[enemies.Count - 1];
                enemies.Remove(tmp);
                Destroy(tmp);
            }
        }
    }
}
