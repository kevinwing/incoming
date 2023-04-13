using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    // Component References
    protected Rigidbody2D _rigidbody;

    // GameObject References
    // [SerializeField] protected GameObject _ball;

    // Animator
    [SerializeField] protected Animator _animator;

    // Vector values for movement
    protected Vector2 _movement;

    // Transforms
    protected Transform _aimTransform;
    protected Transform _ballTransform;

    // Angles of rotation
    protected float _angle;
    protected bool hasBall = false;

    // Settings
    [SerializeField] protected float _speed = 5;

    void Start()
    {
        this._rigidbody = GetComponent<Rigidbody2D>();
        _aimTransform = transform.Find("Aim");
        _ballTransform = _aimTransform.Find("Ball");
    }

    // void Update()
    // {
    //     ProcessInputs();
    //     HandleAiming();

    //     // Animation movement input
    //     Animate();
    // }

    // void FixedUpdate()
    // {
    //     Move();
    // }

    protected void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        this._movement = new Vector2(moveX, moveY).normalized; // TODO: come back to this
    }

    protected void Move()
    {
        this._rigidbody.velocity = new Vector2(this._movement.x * this._speed, this._movement.y * this._speed); // apply new direction and velocity
    }

    protected void HandleAiming()
    {
        Vector3 mousePosition = Utils.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        _aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    protected void Animate()
    {
        this._animator.SetFloat("Horizontal", this._movement.x);
        this._animator.SetFloat("Vertical", this._movement.y);

        this._animator.SetFloat("Speed", this._movement.sqrMagnitude);
    }

    public void setSpeed(float newSpeed)
    {
        this._speed = newSpeed;
    }

    public float getSpeed()
    {
        return this._speed;
    }
}
