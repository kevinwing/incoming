// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public Transform aimTransform;
    public Transform ballTransform;
    public GameObject ball;
    private SpriteRenderer ballSpriteRenderer;
    // private Vector3 ballPosition;

    // [SerializeField] private PlayerPickupBall playerPickupBall;

    private void Awake()
    {
    }

    private void Start()
    {
        // playerPickupBall = GameObject.Find("Player").GetComponent<PlayerPickupBall>();
        this.aimTransform = transform.Find("Aim");
        this.ballTransform = aimTransform.Find("Ball");
        ballSpriteRenderer = GameObject.Find("Ball").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleShooting();
    }

    public void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0) && Player.hasBall)
        {
            Instantiate(ball, ballTransform.position, Quaternion.identity);
            Player.hasBall = false;
            ballSpriteRenderer.enabled = false;
        }
    }
}
