using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    

    public static AudioManager Instance;
    public AudioMixer masterMixer;
    [SerializeField] AudioSource musicSource, effectSource;
    [SerializeField] Slider masterSlider;
    public float frequency;


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

}
