using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    //camera
    public GameObject camera;

    //manager
    public GameObject manager;

    //public cover object array and tracker
    public GameObject coverPoint;
    protected GameObject[] all = {};
    protected int index = 0;

    //public self ref
    public GameObject AI_inst;

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

    //get health
    public float GetHealth()
    {
        return health;
    }

    //set health
    public void setHealth(float AIHealth)
    {
        health = AIHealth;

        if (health == 0)
            respawn();
    }

    //damage
    public void DoDamage(float damage)
    {
        if(health - damage >= 0)
        {
            if (health - damage > 100)
            {
                setHealth(100);
            }
            else
            {
                setHealth(health - damage);
            }
        }
        else
        {
            setHealth(0);
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
        GameObject spawn = GameObject.FindWithTag("spawner");
        Instantiate(gameObject, spawn.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}