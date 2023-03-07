using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float speed = 10f;

    private float entityYBounds = -6f;
    // private float entityXBounds = 11f;
    // private float entityYRespawnPos = 8f;

    private void Awake()
    {
        // set random spawn position
        // float randomXPos = Random.Range(-entityXBounds, entityXBounds);
        // transform.position = new Vector3(randomXPos, entityYRespawnPos, 0);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // if(transform.position.y < entityYBounds)
        // {
        //     Destroy(this);
        // }
    }
}
