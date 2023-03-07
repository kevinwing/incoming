using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playbackCheck : MonoBehaviour
{

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {

        source = GetComponent<AudioSource>();

        if(!source.isPlaying){
            Time.timeScale = 0;
            Debug.Log("Couldn't play back.");

        }
    }


}
