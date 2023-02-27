using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody2D rBody;
    private float maxHealth = 100;
    public HealthBar healthbar;
    //private bool regenerating = false;
    

    [SerializeField]
    public float currentHealth;

    [SerializeField]
    int regenRate = 5;
    
    void Awake(){
        rBody = GetComponent<Rigidbody2D>();
        SetHealth(maxHealth);
        InvokeRepeating("RegenerateHealth", 1 , 1); //(methodname,time,repeatrate)
    }

    public void SetHealth(float health){
        currentHealth = health;
        //healthbar.setHealth(health);  //Object reference issue from Damage Test
    }
    public float GetHealth(){
        return currentHealth;
    }

    public void DoDamage(int damage){
        //audioSource.clip = hitSound;
        //audioSource.Play();
        
        if(currentHealth - damage >= 0){
            if(currentHealth - damage > 100){
            SetHealth(100);
            }
            else{
                SetHealth(currentHealth - damage);
            }
        }
        else{
            SetHealth(0);
        }

    }

    private void RegenerateHealth(){
        if(currentHealth < maxHealth){
            //regenerating = true;
            if(currentHealth + regenRate < maxHealth ){
                currentHealth += regenRate;
            }
            else{
                currentHealth = maxHealth;
            }    
            healthbar.setHealth(currentHealth);
        
        }
        else
        {
            //CancelInvoke("RegenerateHealth");
            //regenerating = false;
        }

    }

    // On collision with ball TakeDamage
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("ball")){
            DoDamage(20);
            
        }
        //if(collision.gameObject.CompareTag("goal")){
            //GameManager.Victory();
        //}
    }
/*
        if(collision.gameObject.CompareTag("coin")){

            GameManager.coinScore();
            Debug.Log("player.coinscore");

        }
    }
*/

}
