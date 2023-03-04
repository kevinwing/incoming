using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stresser : MonoBehaviour
{
    //AI
    public GameObject AI;

    //testing variables
    private float FPS = 300;
    private bool testing;
    private int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        //start spawning
        StartCoroutine(spawnAI());
        Invoke("register", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //check fps
        FPS = (1.0f / Time.deltaTime);

        if (Time.timeScale != 0)
            Debug.Log(FPS);

        //freeze is falls below 60
        if (FPS < 60 && testing)
        {
            Debug.Log("60 FPS lower cap breached...freezing.");
            Time.timeScale = 0;
        }
    }

    //spawn new AI
    IEnumerator spawnAI()
    {
        while (true)
        {
            yield return new WaitForSeconds(.01f);
            Instantiate(AI, new Vector3(0f, 0f, 0f), Quaternion.identity);
            num++;
        }
    }

    //start testing
    void register()
    {
        testing = true;
    }

    //show number of spawned AIs in top left
    void OnGUI()
    {
        GUI.Label(new Rect(0,0,100,100), num.ToString());
    }
}
