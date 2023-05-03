using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{   
    public GameObject mainMenuUI;
    public GameObject helpMenuUI;
    public GameObject settingsMenuUI;
    public GameObject returnButton;
    public GameManager GameManager;
    public Toggle bcToggle;
    public bool bcMode;


    public void Start(){
        bcToggle.isOn = false;
    }

    public void PlayGame(){
        GameManager.SetGameState(GameState.Wave);
    }

    public void Quit(){
        Application.Quit();
    }

    public void Help(){
        mainMenuUI.SetActive(false);
        helpMenuUI.SetActive(true);

    }

    public void Settings(){
        mainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        //logoText.SetActive(false);
        //largeLogo.SetActive(true);

    }
    public void Return(){
        helpMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
        mainMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);

    }

    public void BCMode(bool tickOn){
        if(tickOn){
            bcMode = true;
            Debug.Log("BC mode true");

        }
        else{
            bcMode = false;
            Debug.Log("BC mode false");

        }
        GameManager.SetBC(bcMode);
        


    }

}

