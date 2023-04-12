using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
*       Pickup that adds double the base pickup health boost, and adds .5 to regen rate
*
*
*/


public class MegaBoost : Pickup
{

    public override void TriggerBonus() {
        if(phealth.currentHealth < 100){
                phealth.AddHealth(healthBoost*2);
                phealth.AddRegen(1f);
                Destroy(gameObject);
        }

    }

}
