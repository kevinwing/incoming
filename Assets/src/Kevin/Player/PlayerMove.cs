using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float _speed = 5f;
    private Rigidbody2D _rigidbody;
    private Vector2 _movement;
    private Transform _transform;
    [SerializeField] Animator _animator;

    private void Awake()
    {
        this._rigidbody = GetComponent<Rigidbody2D>();
        this._transform = this.transform;
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
        Animate();
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        this._movement = new Vector2(moveX, moveY).normalized; // TODO: come back to this
    }

        /// <summary>
    /// Method to handle the player movement
    /// </summary>
    private void Move()
    {
        this._rigidbody.velocity = new Vector2(this._movement.x * this._speed, this._movement.y * this._speed); // apply new direction and velocity
    }

    private void Animate()
    {
        this._animator.SetFloat("Horizontal", this._movement.x);
        this._animator.SetFloat("Vertical", this._movement.y);

        this._animator.SetFloat("Speed", this._movement.sqrMagnitude);
    }
}
