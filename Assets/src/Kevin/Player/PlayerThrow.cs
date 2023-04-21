// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public Transform aimTransform;
    public Transform ballTransform;
    public GameObject ball;
    // private Vector3 ballPosition;

    [SerializeField] private PlayerPickupBall playerPickupBall;

    private void Awake()
    {
        this.aimTransform = transform.Find("Aim");
        this.ballTransform = aimTransform.Find("Ball");
    }

    private void Start()
    {
        // playerPickupBall = GameObject.Find("Player").GetComponent<PlayerPickupBall>();
    }

    void Update()
    {
        HandleShooting();
    }

    public void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Vector3 mousePostition = GetMouseWorldPosition();
            // ballPosition = ballTransform.position;

            Instantiate(ball, ballTransform.position, Quaternion.identity);
        }
    }
}
