using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
*       Pickup that adds double the base pickup health boost, and adds .5 to regen rate
*
*       TriggerBonus overrides for dynamic binding.
*
*
*       I will add a timer to return regen rate after specified time
*/


public class MegaBoost : Pickup
{

    public override void TriggerBonus() {
        if(phealth.currentHealth < 100){
                phealth.AddHealth(healthBoost*2);
                FindObjectOfType<AudioManager>().Play("MegaBoost");
                phealth.AddRegen(1f);
                gameObject.SetActive(false);
                Destroy(gameObject);
                
        }

    }

}
