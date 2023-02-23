using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    //speed and body
    public float speed;
    public Rigidbody2D body;
    public Collider2D coll;

    //public player and speed
    public GameObject player;

    //private start location
    private Vector2 start;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        //direction of player
        direction = player.transform.position - transform.position;
        direction.Normalize();

        //release
        release();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function to release the ball
    private void release()
    {
        //total velocity
        body.velocity = direction * speed;
    }
}
