using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody;
    private float xInput = 0f;
    private float yInput = 0f;
    public float pSpeed = 5f;

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
        rbody.velocity = Vector2.zero; // set current velocity to 0
        xInput = Input.GetAxisRaw("Horizontal"); // get horizontal(x) input
        yInput = Input.GetAxisRaw("Vertical"); // get vertical(y) input

        Vector3 dVector = new Vector3(xInput, yInput, 0); // set new direction parameters
        rbody.velocity = dVector.normalized * pSpeed; // apply new direction and velocity

        // if (Input.GetKey(KeyCode.S)) {
        //     rbody.velocity = new Vector2(0, -pSpeed * Time.deltaTime);
        // }
        // if (Input.GetKey(KeyCode.D)) {
        //     rbody.velocity = new Vector2(pSpeed * Time.deltaTime, 0);
        // }
        // if (Input.GetKey(KeyCode.A)) {
        //     rbody.velocity = new Vector2(-pSpeed * Time.deltaTime, 0);
        // }
        // if (Input.GetKey(KeyCode.W)) {
        //     rbody.velocity = new Vector2(0, pSpeed * Time.deltaTime);
        // }
    }
}
