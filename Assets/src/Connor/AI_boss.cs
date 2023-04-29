using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public sealed class AI_boss : AI
{
    //insurance of singleton properties
    private static readonly AI_boss instance = new AI_boss();

    //flipping
    private bool flipping = false;

    //awareness of players location
    private GameObject player;


    static AI_boss() {}

    private AI_boss() {} // call the base constructor with a value for health

    public static AI_boss Instance
    {
        get { return instance; }
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Invoke("flip", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //get direction of movement for animator
        AIMovement = new Vector2(target.x, target.y).normalized;

        //animation
        this._animator.SetFloat("Horizontal", this.AIMovement.x);
        this._animator.SetFloat("Vertical", this.AIMovement.y);
        this._animator.SetFloat("Speed", this.AIMovement.sqrMagnitude);

        if (flipping)
        {
            transform.Rotate (Vector3.forward * -0.5f);
        }
    }

    //DON'T spawn new AI and kill
    public override void kill()
    {
        //TODO - create unique kill animation
        Destroy(gameObject);
    }

    //initiate flip
    private void flip()
    {
        flipping = !flipping;
        rb.velocity = new Vector2(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
        Invoke("unflip", 1.0f);
    }

    //stop flip and reset vel
    private void unflip()
    {
        flipping = !flipping;
        rb.velocity = new Vector2(0f, 0f);
    }
}
