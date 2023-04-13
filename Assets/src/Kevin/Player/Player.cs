using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed;
    private int _health = 100;
    private bool is_dead = false;

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
