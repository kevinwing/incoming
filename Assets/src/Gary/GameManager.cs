using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numberEnemies = 5;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void newEnemy()
    {
        if (numberEnemies > 0)
        {
            GameObject spawn = GameObject.FindWithTag("spawner");
            Instantiate(gameObject, spawn.transform.position, Quaternion.identity);
            --numberEnemies;
        }
    }
}
