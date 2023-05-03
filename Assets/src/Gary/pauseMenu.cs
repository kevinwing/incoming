using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject settingsMenu;
    public GameObject healthBar;
    public GameManager GameManager;
    // Update is called once per frame


    public void Pause(){
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Debug.Log("pauseMenu Pause()");
        
    }
    public void UnPause(){
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Debug.Log("pauseMenu UnPause()");
        GameManager.SetGameState(GameState.Wave);

    }
    public void Quit(){
        Application.Quit();
    }

    public void Settings(){
        settingsMenu.SetActive(true);
        //pauseMenuUI.SetActive(false);
        healthBar.SetActive(false);
    }   
    public void MainMenu(){
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Debug.Log("pauseMenu MainMenu()");
        GameManager.SetGameState(GameState.Menu);

    }


    public void Return(){
        //settingsMenu.SetActive(false);
        //pauseMenuUI.SetActive(true);
        //healthBar.SetActive(true);
    }

}
