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
    private int num = 0;
    private bool testing = false;

    // Start is called before the first frame update
    void Start()
    {
        //start spawning
        // StartCoroutine(spawnAI());
        // Invoke("register", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //check fps
        // FPS = (1.0f / Time.deltaTime);

        // if (Time.timeScale != 0)
        //     Debug.Log(FPS);

        // if (FPS < 60 && testing){
        //     Time.timeScale = 0;
        // }

    }

    //spawn new AI
    IEnumerator spawnAI()
    {
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            Instantiate(AI, new Vector3(0f, 0f, 0f), Quaternion.identity);
            num++;
        }
    }

    void register(){
        testing = true;
    }

    //show number of spawned AIs in top left
    void OnGUI()
    {
        GUI.Label(new Rect(0,0,100,100), num.ToString());
    }
}
