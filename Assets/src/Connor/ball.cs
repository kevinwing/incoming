using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    //speed and body
    public float speed;
    public Rigidbody2D body;
    public Collider2D coll;

    //private target and speed
    public GameObject target = null;

    //private start location
    private Vector2 start;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        //direction of target
        setTarget(target);

        //release
        release();

        //Invoke("Tag", 0.05f);

        Invoke("Disable", 1.0f);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    //function to release the ball
    private void release()
    {
        //total velocity
        body.velocity = direction * speed;
    }

    //function to nullify balls on hit with player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("wall")) && (target != null))
        {
            Disable();
        }
    }

    //function to set target for ball to fly at
    public void setTarget(GameObject targ)
    {
        if (target != null)
        {
            direction = targ.transform.position - transform.position;
            direction.Normalize();
        }
        else
        {
            //TODO - make ball launch in direction player is facing
            direction.Set(1.0f, 2.0f);
        }
    }

    private void Disable()
    {
        gameObject.tag = "ball_ground";
    }

    private void Tag()
    {
        gameObject.tag = "ball";
    }
}