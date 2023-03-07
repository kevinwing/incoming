using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 mousePostion;
    private Vector3 ObjPosition;
    private float angle;
    private Rigidbody2D rbody;
    private float xInput = 0f;
    private float yInput = 0f;
    public float pSpeed = 5f;

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        playerTransform = this.transform;
    }

    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // Update is called once per frame
    void Update()
    {
        PlayerAim();
        PlayerMove();
    }

    /// <summary>
    /// Method to handle the player movement
    /// </summary>
    private void PlayerMove()
    {
        xInput = Input.GetAxisRaw("Horizontal"); // get horizontal(x) input
        yInput = Input.GetAxisRaw("Vertical"); // get vertical(y) input

        Vector2 dVector = new Vector2(xInput, yInput); // set new direction parameters
        rbody.velocity = dVector.normalized * pSpeed; // apply new direction and velocity
    }

    public Vector2 CalculateMovement(float h, float v, float deltaTime)
    {
        var x = h * pSpeed * deltaTime;
        var y = v * pSpeed * deltaTime;

        return new Vector2(x, y);
    }

    /// <summary>
    /// Method to handle the direction the player is aiming
    /// </summary>
    private void PlayerAim()
    {
        mousePostion = Input.mousePosition;
        mousePostion.z = 5.23f;

        ObjPosition = Camera.main.WorldToScreenPoint(playerTransform.position);

        mousePostion.x = mousePostion.x - ObjPosition.x;
        mousePostion.y = mousePostion.y - ObjPosition.y;

        angle = Mathf.Atan2(mousePostion.y, mousePostion.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0,0, angle));
    }

    private void PlayerShoot()
    {
        //
    }
}
