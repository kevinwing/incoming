using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
*       Base class for pickups.  
*       
*       TriggerBonus is overridden for dynamic binding.
*
*
*/


public class Pickup : MonoBehaviour
{
    public PlayerHealth phealth;

    public int healthBoost = 10;

    void Awake(){

        phealth = FindObjectOfType<PlayerHealth>();


    }


    void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.CompareTag("Player")){
            TriggerBonus();
        }
    }


    public virtual void TriggerBonus() {

        if(phealth.currentHealth < 100){
                phealth.AddHealth(healthBoost);
                FindObjectOfType<AudioManager>().Play("Pickup");
                gameObject.SetActive(false);
                Destroy(gameObject);
                
        }
    }

}
