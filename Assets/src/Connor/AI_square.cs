using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_square : MonoBehaviour
{
    //public player and speed
    public GameObject player;
    public float speed;

    //private distance float
    private float distance;

    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnBall());
    }

    // Update is called once per frame
    void Update()
    {
        //determine the distance and direction of the player
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        //function I found to get the AI to face the cover its moving to
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //move
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        //pick new cover if made it
        if (this.transform.position == player.transform.position)
        {
            reCover();
        }

    }

    private void reCover()
    {
        //temp array for all cover objects
        GameObject[] all = GameObject.FindGameObjectsWithTag("cover");
        int length = all.Length;

        //assign new random cover
        player = all[(int)Random.Range(0, length)];

    }

    //spawn new barrel
    IEnumerator spawnBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            Instantiate(ball, this.transform.position, Quaternion.identity);
        }
    }
}
