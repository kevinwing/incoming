using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerBase
{
    private static Player _instance;
    public static Player Instance { get { return _instance; } }

    [SerializeField] protected GameObject _ball;
    private Vector3 _mousePostion;
    private int _health = 100;
    [SerializeField] protected bool _is_dead = false;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

    }

    void Update()
    {
        ProcessInputs();
        HandleShooting();
        HandleAiming();
        Animate();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_ball, _ballTransform.position, Quaternion.identity);
        }
    }

    public virtual void TakeDamage(int dmgAmt)
    {
        this._health -= dmgAmt;
        if (this._health <= 0)
        {
            this._is_dead = true;
        }
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
        return this._is_dead;
    }
}
