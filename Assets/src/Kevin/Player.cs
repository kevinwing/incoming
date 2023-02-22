using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody;
    public float pSpeed = 2000f;

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.S)) {
            rbody.velocity = new Vector2(0, -pSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) {
            rbody.velocity = new Vector2(pSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A)) {
            rbody.velocity = new Vector2(-pSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.W)) {
            rbody.velocity = new Vector2(0, pSpeed * Time.deltaTime);
        }
    }
}
