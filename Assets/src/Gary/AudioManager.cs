using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
*   call play function on clip within sounds array in AudioManager with:
*      FindObjectOfType<AudioManager>().Play("clipname");
*
*
*
*/

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    
    public static AudioManager Instance;
    public AudioMixer masterMixer;
    [SerializeField] 
    AudioSource musicSource, effectSource;
    
    [SerializeField] 
    Slider masterSlider;
   
    public float frequency;
    public PlayerHealth pHealth;

    Scene m_scene;
    string sceneName;
    

    void Awake(){
        //make singleton -- Make sure this persists through scenes and that there are not multiple instances.
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        
        foreach(Sound x in sounds){  //Adds audiosouce per sound added to sounds array in inspector, adds parameters
            x.source = gameObject.AddComponent<AudioSource>();
            x.source.clip = x.clip;
            x.source.volume = x.volume;
            x.source.loop = x.loop;
            x.source.outputAudioMixerGroup = x.audioMixerGroup;
        }

        m_scene = SceneManager.GetActiveScene();
        sceneName = m_scene.name;
        if(  sceneName == "Main Menu"){
            Play("Title");
        }
        if( sceneName == "Game"){
            Play("Action");
            
        }

    
    }
    
    public void Play (string name){
        Sound x = Array.Find(sounds, sound => sound.name == name);  // Find sound with name
        
        if(!x.source.isPlaying || name == "Hit"){
            x.source.Play();
        }
        if( name == "Action"){
            Stop("Title");
        }

    } 

    public void Stop (string name){
        Sound x = Array.Find(sounds, sound => sound.name == name);  // Find sound with name
        
        if(x.source.isPlaying){
            x.source.Stop();
        }
    }

    public void PlayLowHealthAudio (){
        Play("Heartbeat");
        Play("Ringing");

    }

    public void PlayNext (){
        Play("Action");
        Stop("Title");

    }
    
    public void SetMasterLvel(float sliderValue){

        masterMixer.SetFloat("masterVol", Mathf.Log10(sliderValue) * 20);
    }
    
    public float SetLowPass(float health){
        
        float frequency = health * Mathf.Pow((health/10), 2.5f);
        
        if(frequency > 22000){ //Max freq thresh
            frequency = 22000;
        }
        if(frequency < 120){ //Min freq thresh
            frequency = 120;
        }

        if(health > 10 && health < 100){

            masterMixer.SetFloat("lowPassFreq", frequency); //<<------test can't find masterMixer
        }
        return frequency;
    }

    public void SetLowPassDirect(float frequency){
        
   
        
        if(frequency > 22000){ //Max freq thresh
            frequency = 22000;
        }
        if(frequency < 120){ //Min freq thresh
            frequency = 120;
        }

        masterMixer.SetFloat("lowPassFreq", frequency); 
        

    }

}
