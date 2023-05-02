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

    //ball coroutine
    private Coroutine spawnBallCoroutine;

    //awareness of players location
    private GameObject player;

    //dying
    private bool dying = false;

    //defeat sprite
    public Sprite defeat;

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
        InvokeRepeating("flip", 2.0f, 5.0f);
        //anim = gameObject.GetComponent<Animation>();

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
        spawnBallCoroutine = StartCoroutine(spawnBall());
    }

    // Update is called once per frame
    void Update()
    {
        if (!dying)
        {
            //get direction of movement for animator
            AIMovement = new Vector2(target.x, target.y).normalized;

            //animation
            this._animator.SetFloat("Horizontal", this.AIMovement.x);
            this._animator.SetFloat("Vertical", this.AIMovement.y);
            this._animator.SetFloat("Speed", this.AIMovement.sqrMagnitude);

            //flipping
            if (flipping)
            {
                transform.Rotate (Vector3.forward * -0.5f);
            }

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
        }
    }

    //DON'T spawn new AI and kill
    public override void kill()
    {
        //start death
        dying = true;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        rb.velocity = Vector3.zero;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defeat;

        //coroutines
        StopCoroutine(spawnBallCoroutine);
        spawnBallCoroutine = null;
        CancelInvoke();

        //animation seize
        this._animator.SetFloat("Horizontal", 0.0f);
        this._animator.SetFloat("Vertical", 0.0f);
        this._animator.SetFloat("Speed", 0.0f);

        //die
        Invoke("end", 2.0f);
    }

    //trigger recover
    private void end()
    {
        Destroy(gameObject);
    }

    //trigger recover
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Invoke("reCover", 0.5f);
    }

    //find new cover
    public void reCover()
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

    //throw new ball
    IEnumerator spawnBall()
    {
        while (true)
        {
            //wait
            yield return new WaitForSeconds(4);

            GameObject temp = GameObject.FindWithTag("Player");
            GameObject thisBall = Instantiate(ball, this.transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            thisBall.GetComponent<ball>().target = temp;
            hasBall = false;
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
            DoDamage(20);
            shake();
            this._animator.SetBool("Damaged", true);
            Invoke("undamage", 0.5f);
        }
    }

    //stop damage anim
    private void undamage()
    {
        this._animator.SetBool("Damaged", false);
    }

    //initiate flip
    private void flip()
    {
        flipping = !flipping;
        rb.velocity = new Vector2(Random.Range(Random.Range(-6.0f, -4.0f), Random.Range(4.0f, 6.0f)), Random.Range(Random.Range(-6.0f, -4.0f), Random.Range(4.0f, 6.0f)));
        Invoke("unflip", 1.0f);
    }

    //stop flip and reset vel
    private void unflip()
    {
        flipping = !flipping;
        rb.velocity = new Vector2(0f, 0f);
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
