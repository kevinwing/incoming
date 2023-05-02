using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    /* ---VARIABLES--- */

    //camera
    public GameObject camera;

    //manager
    public GameObject manager;

    //public cover object array and tracker
    public GameObject coverPoint;
    protected GameObject[] all = {};
    protected int index = 0;

    //movement
    protected Vector2 AIMovement;

    //health
    [SerializeField]
    protected float health = 100;

    //collider
    public Collider2D coll;

    //dodgeball ref and has bool
    public GameObject ball;
    public bool hasBall;

    //nav mesh ref
    protected NavMeshAgent agent;

    //target vector3
    protected Vector3 target;

    //animator
    [SerializeField]
    protected Animator _animator;

    //rigidbody
    public Rigidbody2D rb;

    //Private Class Data variable
    private AI_data aiData;

    /* ---FUNCTIONS--- */

    public void Awake()
    {
        aiData = new AI_data(100.0f, this);
    }

    //find new index
    public void reIndex()
    {
        index = (int)Random.Range(0, all.Length - 1);
    }

    //get index
    public int getIndex()
    {
        return index;
    }

    //set nav mesh destination
    protected void setPos()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }

    //damage
    public void DoDamage(float damage)
    {
        if(aiData.getHealth() - damage >= 0)
        {
            if (aiData.getHealth() - damage > 100)
            {
                aiData.setHealth(100);
            }
            else
            {
                aiData.setHealth(aiData.getHealth() - damage);
            }
        }
        else
        {
            aiData.setHealth(0);
            respawn();
        }
    }

    //respawn new AI if hit
    private void respawn()
    {
        //sling enemy
        rb.velocity = new Vector2(7f, 7f);

        //shake and kill
        shake();
        Invoke("kill", 0.5f);
    }

    //func to shake camera on hit
    public void shake()
    {
        //establish camera
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.GetComponent<camera_shake>().TriggerShake();
    }

    //spawn new AI and kill
    public virtual void kill()
    {
        Destroy(gameObject);
    }

    public AI_data GetAIData()
    {
        return aiData;
    }

    public class AI_data
    {
        private float Health;
        private AI aiInstance;

        public float getHealth()
        {
            return Health;
        }

        public void setHealth(float h)
        {
            Health = h;
            if (Health <= 0)
                aiInstance.respawn();
        }

        public AI_data(float health, AI ai)
        {
            Health = health;
            aiInstance = ai;
        }
    }
}