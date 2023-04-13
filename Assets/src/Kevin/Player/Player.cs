using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed;

    // [SerializeField] private Animator _animator;
    // private Vector2 _movement;
    // private Transform playerTransform;
    // private Vector3 mousePostion;
    // private Vector3 ObjPosition;
    // private float angle;
    // private Rigidbody2D rbody;
    // public GameObject ball;
    private int _health = 100;
    private bool is_dead = false;

    void Awake()
    {
        // rbody = GetComponent<Rigidbody2D>();
        // playerTransform = this.transform;
        // this._speed = 5f;
    }

    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // Update is called once per frame
    void Update()
    {
        // PlayerAim();
        // ProcessInputs();
        // this._animator.SetFloat("Horizontal", this._movement.x);
        // this._animator.SetFloat("Vertical", this._movement.y);

        // this._animator.SetFloat("Speed", this._movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        // Move();
    }

    // private void ProcessInputs()
    // {
    //     float moveX = Input.GetAxisRaw("Horizontal");
    //     float moveY = Input.GetAxisRaw("Vertical");

    //     pMovement = new Vector2(moveX, moveY).normalized; // TODO: come back to this
    // }

    // /// <summary>
    // /// Method to handle the player movement
    // /// </summary>
    // private void Move()
    // {
    //     // xInput = Input.GetAxisRaw("Horizontal"); // get horizontal(x) input
    //     // yInput = Input.GetAxisRaw("Vertical"); // get vertical(y) input

    //     // Vector2 dVector = new Vector2(xInput, yInput); // set new direction parameters
    //     rbody.velocity = new Vector2(pMovement.x * _speed, pMovement.y * _speed); // apply new direction and velocity
    // }

    public void TakeDamage(int dmgAmt)
    {
        this._health -= dmgAmt;
        if (this._health <= 0)
        {
            this.is_dead = true;
        }
    }

    public void setSpeed(float newSpeed)
    {
        this._speed = newSpeed;
    }

    public float getSpeed()
    {
        return this._speed;
    }

    public void setHealth(int newHealth)
    {
        this._health = newHealth;
    }

    public int getHealth()
    {
        return this._health;
    }

    public bool isDead()
    {
        return this.is_dead;
    }
}
