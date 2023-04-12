using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject settingsMenu;
    public GameObject healthBar;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            if(isPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause(){
        pauseMenuUI.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Quit(){
        Application.Quit();
    }

    public void Settings(){
        settingsMenu.SetActive(true);
        pauseMenuUI.SetActive(false);
        healthBar.SetActive(false);
    }   


    public void Return(){
        settingsMenu.SetActive(false);
        pauseMenuUI.SetActive(true);
        healthBar.SetActive(true);
    }
}
