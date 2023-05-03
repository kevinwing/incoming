using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public pauseMenu PauseMenu;
    public GameManager GameManager;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) ){
            
            if(isPaused == false){
                Debug.Log("Pause Button Pressed- Pausing");
                GameManager.SetGameState(GameState.Paused);
                PauseMenu.Pause();

            }
            else{
                Debug.Log("Pause Button Pressed- UnPausing");
                GameManager.SetGameState(GameState.Wave);
                PauseMenu.UnPause();

            }


        }
    }
}
