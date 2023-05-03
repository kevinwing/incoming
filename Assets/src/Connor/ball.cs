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
    public void Start()
    {
        //direction of target
        setTarget(target);

        //release
        release();

        Invoke("Disable", 1.5f);
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
            Invoke("Disable", 0.01f);
        }
    }

    //function to set target for ball to fly at
    public void setTarget(GameObject targ)
    {
        if (target != null)
        {
            //shoot at passed target
            direction = targ.transform.position - transform.position;
            direction.Normalize();
        }
        else
        {
            //make ball launch in direction player is facing
            GameObject player = GameObject.FindWithTag("Player");
            GameObject playerChild = player.transform.GetChild(0).gameObject;
            direction = playerChild.transform.right;
        }
    }

    //disable ball
    private void Disable()
    {
        gameObject.tag = "ball_ground";
        gameObject.layer = LayerMask.NameToLayer("TransparentFX");
    }
}