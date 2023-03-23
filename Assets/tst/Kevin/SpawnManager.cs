using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject entityPrefab;
    private float xSpawnRange = 8f; // used to determine the x-range the entities will spawn in
    private float ySpawnPos = 8f; // y position where entities will spawn
    private float spawnRate = 5f; // the number in seconds before the next wave will spawn

    private int waveSize = 1; // intiial wave size
     private float entityYBounds = -6f; // y position where entities will be destroyed
    private float entityXBounds = 8f;

    // void awake()
    // {
    // }

    // public TMP numEntitiesText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            GameObject[] objs = new GameObject[waveSize];

            // string infoText = string.Format("Num Entities Spawned: {0}", waveSize.ToString());
            // numEntitiesText.text = infoText;
            for (int i = 0; i < waveSize; i++)
            {
                objs[i] = (GameObject)Instantiate(entityPrefab, new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPos, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnRate);

            foreach (GameObject obj in objs)
            {
                DestroyImmediate(obj);
            }

            waveSize *= 2;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), "Entities: " + waveSize.ToString());
    }
}
