using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{


    public GameManager GameManager;

    public void Settings(){


    }
    public void Quit(){
        Application.Quit();
    }
    public void Restart(){
        GameManager.SetGameState(GameState.Wave);
    }
    public void MainMenu(){
        GameManager.SetGameState(GameState.Menu);

    }
}
