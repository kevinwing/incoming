using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public static event Action<GameState>  GameStateChanged;
    Scene m_scene;
    string sceneName;
    public GameState State;

    void Awake(){
        //make singleton -- Make sure this persists through scenes and that there are not multiple instances.
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        

    
    }

    void Start() {


        m_scene = SceneManager.GetActiveScene();
        sceneName = m_scene.name;
        if(  sceneName == "Main Menu"){
            SetGameState(GameState.Menu);
        }
        if( sceneName == "Game"){
            SetGameState(GameState.Wave);
        }

        
    }
    public int numberEnemies = 5;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }


    public void SetGameState(GameState newState) {

        State = newState;

        switch(newState) {
            case GameState.Menu:
                FindObjectOfType<AudioManager>().Play("Title");
                break;
            case GameState.Wave:
                FindObjectOfType<AudioManager>().Play("Action");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
                break;
            case GameState.Transition:
                break;
            case GameState.Boss:
                break;
            case GameState.Victory:
                break;
            case GameState.Death:
                break;

        }

        //Broadcast event that state changed
        GameStateChanged?.Invoke(newState);  // ? means invoke if anyone is subscribed to event
    }

    


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


public enum GameState {
    Menu,
    Wave,
    Transition,
    Boss,
    Victory,
    Death

}