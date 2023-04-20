using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Rigidbody2D rBody;
    private float maxHealth = 100;
    public HealthBar healthbar;
    public AudioManager audioManager;
    public GameManager GameManager;
    //private bool isDead;
    //private bool regenerating = false;
    

    [SerializeField]
    public float currentHealth;

    
    float regenRate = .5f;
    
    void Awake(){
        rBody = GetComponent<Rigidbody2D>();
        SetHealth(maxHealth);
        InvokeRepeating("RegenerateHealth", .1f , .1f); //(methodname,time,repeatrate)
        //isDead = false;
    }

    public void SetHealth(float health){
        currentHealth = health;
        healthbar.setHealth(health);  //Object reference issue from Damage Test
    }
    public float GetHealth(){
        return currentHealth;
    }

    public void AddHealth(int health){
        if(currentHealth + health > 100){
            SetHealth(100);
        }
        else{
            SetHealth(currentHealth + health);
        }
    }

    public void AddRegen(float rate){
        regenRate += rate;

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
                FindObjectOfType<AudioManager>().Play("Hit");
                if(currentHealth < 40){
                    FindObjectOfType<AudioManager>().PlayLowHealthAudio();
                    
                }
            }
        }
        else{


            SetHealth(0);
            //isDead = true;
            GameManager.SetGameState(GameState.Death);
        
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
            audioManager.SetLowPass(currentHealth);
        
        }
        else
        {
            //CancelInvoke("RegenerateHealth");
            //regenerating = false;
        }

    }

    // On collision with ball TakeDamage
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("ball") || collision.gameObject.CompareTag("ball_ground")){
            DoDamage(80);
            Debug.Log("Ball Collision");
            
        //}
        //if(collision.gameObject.CompareTag("goal")){
            //GameManager.Victory();
        }
    }


}
