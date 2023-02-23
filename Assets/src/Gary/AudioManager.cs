using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    

    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSource, effectSource;

    void Awake(){
        //make singleton
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }

        Debug.Log("Trigger Background Music");

    }



}
