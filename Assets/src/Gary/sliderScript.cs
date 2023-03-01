using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class sliderScript : MonoBehaviour
{
 
    public AudioMixer masterMixer;

    public void SetMasterLvel(float sliderValue){

        masterMixer.SetFloat("masterVol", Mathf.Log10(sliderValue) * 20);
    }

}
