using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_square : AI
{
    // Start is called before the first frame update
    public void Start()
    {
        //establish navigation
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        //grab ball
        hasBall = true;

        //establish first random cover object
        all = GameObject.FindGameObjectsWithTag("cover");
        reIndex();
        coverPoint = all[index];

        //start throwing
        StartCoroutine(spawnBall());
    }

    // Update is called once per frame
    void Update()
    {
        //determine the target cover point location, correcting if it somehow becomes null
        if (coverPoint == null)
        {
            reIndex();
            coverPoint = all[index];
            target = coverPoint.transform.position;
        }
        else
        {
            target = coverPoint.transform.position;
        }

        //set target
        setPos();

        //get direction of movement for animator
        AIMovement = new Vector2(target.x, target.y).normalized;

        //animation
        this._animator.SetFloat("Horizontal", this.AIMovement.x);
        this._animator.SetFloat("Vertical", this.AIMovement.y);
        this._animator.SetFloat("Speed", this.AIMovement.sqrMagnitude);
    }

    //trigger recover
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Invoke("reCover", 1.0f);
    }

    //find new cover
    public void reCover()
    {
        //if has ball, get new cover, else, get new ball
        if (hasBall)
        {
            //pick new cover not equal to current one
            int temp = (int)Random.Range(0, all.Length);
            while (temp == index)
            {
                temp = (int)Random.Range(0, all.Length);
            }

            //assign index
            index = temp;

            //assign new cover
            coverPoint = all[index];
        }
        else
        {
            //run down nearest ball
            chaseBall();
        }
    }

    //throw new ball
    IEnumerator spawnBall()
    {
        while (true)
        {
            //wait
            yield return new WaitForSeconds(4);

            //occasional recover/ball run to keep things spicy
            if (hasBall)
            {
                reIndex();
                coverPoint = all[index];
            }
            else
            {
                chaseBall();
            }

            //throw if has ball
            if (hasBall)
            {
                GameObject temp = GameObject.FindWithTag("Player");
                GameObject thisBall = Instantiate(ball, this.transform.position, Quaternion.identity);
                Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                thisBall.GetComponent<ball>().target = temp;
                hasBall = false;
            }
        }
    }

    //2d collider handler
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("ball_ground"))
        {
            hasBall = true;
            Destroy(collision.gameObject);
            reCover();
        }

        if (collision.gameObject.CompareTag("ball_p"))
        {
            DoDamage(100);
        }
    }

    //function for guiding the AI to a new ball to pick up
    private void chaseBall()
    {
        //nullify coverPoint
        coverPoint = null;

        //get array of balls
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball_ground");
        GameObject closest = null;
        float distance = 0.0f;

        //find closest ball
        for (int i = 0; i < balls.Length; i++)
        {
            if (Vector3.Distance(balls[i].transform.position, this.transform.position) > distance)
            {
                distance = Vector3.Distance(balls[i].transform.position, this.transform.position);
                closest = balls[i];
            }
        }

        //assign target
        coverPoint = closest;
    }

    //give ball
    public void giveBall()
    {
        hasBall = true;
    }
}