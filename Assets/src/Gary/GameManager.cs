using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



/*
*   
*   Includes state pattern
*   
*   TO CHANGE GAMESTATE ADD
*    public GameManager GameManager;
*
*
*   THEN CALL
*        GameManager.SetGameState(GameState.nameofthestateyouwanttoset);
*
*
*
*
*
*/





public class GameManager : MonoBehaviour
{
    //public GameObject deathTestManager;
    public static GameManager Instance;
    //public GameObject pauseMenuUI;
    //public GameObject pauseButton;
    public static event Action<GameState>  GameStateChanged;
    Scene m_scene;
    string sceneName;
    public GameState State;
    public int numberEnemies = 5;
    public static bool BCMode;
    public pauseMenu pausemenu;
    //public MenuButtons menuButtons;

    void Awake(){
        //make singleton -- Make sure this persists through scenes and that there are not multiple instances.
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }

        //isPaused = false;
        

    
    }

    void Start() {

        // Check loaded scene, set GameState accordingly
        m_scene = SceneManager.GetActiveScene();
        sceneName = m_scene.name;
        if(  sceneName == "Main Menu"){
            SetGameState(GameState.Menu);
        }
        if( sceneName == "lvl1"){
            SetGameState(GameState.Wave);
        }



        BCMode = false;
        //pausemenu = FindObjectOfType<pauseMenu>();
        
    }
    
    public void SetBC(bool mode){

        if(mode){
            BCMode = true;
        }


    }



    public void SetGameState(GameState newState) {

        State = newState;

        switch(newState) {
            case GameState.Menu:
                FindObjectOfType<AudioManager>().SetLowPassDirect(22000);

                FindObjectOfType<AudioManager>().Play("Title");
                m_scene = SceneManager.GetActiveScene();
                sceneName = m_scene.name;
                if( sceneName != "Main Menu"){
                    SceneManager.LoadScene("Main Menu");
                }

                break;
            case GameState.Paused:
                Pause();
                break;
            case GameState.Wave: 
                Wave();

                
                break;
            case GameState.Transition:
                // Will Be used inbetween waves or levels
                break;
            case GameState.Boss:

                break;
            case GameState.Victory:
                break;
            case GameState.Death:

                if(BCMode == true){
                    break;
                }
                
                // Trigger new scene
                Time.timeScale = .1f;
                Invoke("Death", .1f);




                break;

        }

        //Broadcast event that state changed
        GameStateChanged?.Invoke(newState);  // ? means invoke if anyone is subscribed to event
    }

    private void Pause(){

        //if( isPaused == false){
            FindObjectOfType<AudioManager>().SetLowPassDirect(120);
            //pausemenu.Pause();
            
            Time.timeScale = 0f;
            //Debug.Log("GameManager gamestate pause");
            //isPaused = true;
        //}
       //else{
            //pausemenu.UnPause();

            //Time.timeScale = 1;
            //FindObjectOfType<AudioManager>().SetLowPassDirect(22000);
            //isPaused = false;

        //}
                        
                // NEED TO CALL METHOD TO DISABLE PLAYER ?
    
    } 
    private void Death(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Death");
        Debug.Log("Death Game State");
        FindObjectOfType<AudioManager>().Play("Death");
        FindObjectOfType<AudioManager>().Play("Fall");
        FindObjectOfType<AudioManager>().Play("Birds");
    
    } 

    private void Wave(){
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().SetLowPassDirect(22000);
        Debug.Log("GameManager gamestate wave");

        FindObjectOfType<AudioManager>().Play("Action");
        //pauseMenuUI.SetActive(false);


        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );



        m_scene = SceneManager.GetActiveScene();
        sceneName = m_scene.name;
        if( sceneName != "lvl1"){
            SceneManager.LoadScene("lvl1");
        }


    }

/*
    public void newEnemy()
    {
        if (numberEnemies > 0)
        {
            GameObject spawn = GameObject.FindWithTag("spawner");
            Instantiate(gameObject, spawn.transform.position, Quaternion.identity);
            --numberEnemies;
        }
    }

    */
    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isPaused == false){
            Debug.Log("Pause Button Pressed");
            SetGameState(GameState.Paused);
        }
    }*/
}




public enum GameState {
    Menu,
    Paused,
    Wave,
    Transition,
    Boss,
    Victory,
    Death

}