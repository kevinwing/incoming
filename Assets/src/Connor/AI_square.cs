using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_square : MonoBehaviour
{
    //public cover object array and tracker
    public GameObject coverPoint;
    private GameObject[] all = {};
    private int index = 0;

    //health
    [SerializeField]
    public float health = 100;

    //collider
    public Collider2D coll;

    //dodgeball ref and has bool
    public GameObject ball;
    public bool hasBall;

    //nav mesh ref
    NavMeshAgent agent;

    //target vector3
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
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

        //function I found to get the AI to face the cover its moving to
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
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

    //trigger recover
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Invoke("reCover", 2.0f);
    }

    //set nav mesh destination
    private void setPos()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
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

    //get health
    public float GetHealth()
    {
        return health;
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
                thisBall.GetComponent<ball>().target = temp;
                Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), GetComponent<Collider2D>());
                hasBall = false;
            }
        }
    }

    //set health
    public void setHealth(float AIHealth)
    {
        health = AIHealth;
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

    //2d collider handler
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("ball_ground"))
        {
            hasBall = true;
            Destroy(collision.gameObject);
            reCover();
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
}