using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* virtual/override
In C#, a virtual function is a method that can be overridden by a derived class. When a virtual method is called on an object,
the runtime determines which implementation of the method to use based on the actual type of the object.

To define a virtual function in C#, you can use the "virtual" keyword in the method declaration. For example:

public virtual void MyVirtualMethod()
{
    // Method implementation
}

To override a virtual method in a derived class, you can use the "override" keyword in the method declaration. For example:

public override void MyVirtualMethod()
{
    // Method implementation for the derived class
}

By using virtual functions, you can create a base class with default implementations of methods that can be customized by derived classes.
This enables polymorphic behavior, where a single interface can be used to interact with objects of different types, each with their own
implementation of the virtual method.
*/

/* Dynamic vs. Static Binding
In C#, binding refers to the process of connecting a method call to the method implementation.
There are two types of binding: dynamic binding and static binding.

Static binding, also known as early binding, occurs when the method call is resolved at compile-time.
The compiler determines which method to call based on the type of the object reference. The method call
is bound to the method implementation at compile-time and cannot be changed at runtime.

Dynamic binding, also known as late binding, occurs when the method call is resolved at runtime. The method
call is bound to the method implementation based on the actual type of the object at runtime. This allows
for greater flexibility as the method implementation can be changed at runtime.

In C#, static binding is the default behavior. However, you can use the "dynamic" keyword to enable dynamic
binding for method calls. Dynamic binding is commonly used in scenarios where the exact method implementation
is not known until runtime, such as with plugin architectures or when working with external APIs.
*/

/// <summary>
/// Player class that holds all player data and methods to manipulate player data
/// </summary>
public class Player : MonoBehaviour
{
    public static bool hasBall = false;
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
