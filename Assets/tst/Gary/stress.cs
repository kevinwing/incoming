using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stress : MonoBehaviour
{
    AudioSource source;
    public GameObject sound;
    public Text soundText;
    //public Text timeText;

    int count = 1;
    float time1 = 4;
    // Start is called before the first frame update
    void Start()
    {
        
        //StartCoroutine(playHalfTime());  // Run with loop off
        StartCoroutine(playLooping());  // Run with loop on
    }


/*
    // Update is called once per frame
    IEnumerator playHalfTime()
    {

        
        while(true){
            


            yield return new WaitForSeconds(time1);
            
            //playSFX.Play();
            time1 = time1/1.5f;

            Instantiate(sound, new Vector3(0,0,0), Quaternion.identity);
        }
    }
*/

    IEnumerator playLooping()
    {
        float time = 1;
        count = 1;
        while(true){
            
            yield return new WaitForSeconds(time);
            
            //playSFX.Play();
            //time = time/1.5f;
            int i = 0;
            while(i<count){
                Instantiate(sound, new Vector3(0,0,0), Quaternion.identity);
               ++i;
            }
            count *= 2;


/*
            if(!source.isPlaying){ //moved to playbackCheck.cs
                Time.timeScale = 0;
                break;

            }*/
        }
 
    }
    
    void Update(){

        soundText.text = "Playback Count: " + count.ToString();
        //timeText.text = "Time: " + time1.ToString();
    }
}