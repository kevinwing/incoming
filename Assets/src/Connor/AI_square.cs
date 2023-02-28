using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_square : MonoBehaviour
{
    //public cover object array and tracker
    public GameObject coverPoint;
    private GameObject[] all = {};
    private int index;

    //collider
    public Collider2D coll;

    //dodgeball ref
    public GameObject ball;

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

        //establish first random cover object
        all = GameObject.FindGameObjectsWithTag("cover");
        index = (int)Random.Range(0, all.Length - 1);
        coverPoint = all[index];

        //StartCoroutine(spawnBall());
    }

    // Update is called once per frame
    void Update()
    {
        //determine the target cover point location
        target = coverPoint.transform.position;

        //set target
        setPos();

        //function I found to get the AI to face the cover its moving to
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    //trigger recover
    private void OnTriggerEnter2D(Collider2D coll)
    {
        reCover();
    }

    //set nav mesh destination
    private void setPos()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }

    //find new cover
    private void reCover()
    {
        //if topped out, reset to 0, else randomly pick forward or back
        if (index == all.Length - 1)
        {
            index = (int)Random.Range(0, all.Length - 1);
        }
        else
        {
            if ((Random.value > 0.5f))
            {
                index++;
            }
            else
            {
                if (index == 0)
                    index = all.Length - 1;
                else
                    index--;
            }
        }

        //assign new cover
        coverPoint = all[index];
    }

    //spawn new ball
    IEnumerator spawnBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            Instantiate(ball, this.transform.position, Quaternion.identity);
        }
    }
}
