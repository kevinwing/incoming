using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles pickup of the ball by the player
/// </summary>
public class PlayerPickupBall : MonoBehaviour
{
    private bool hasBall = false; // flag to check if the player has the ball

    /// <summary>
    /// OnCollisionEnter2D is called when this collider/rigidbody has begun touching another rigidbody/collider.
    /// </summary>
    /// <param name="collision">The Instance of the collision</param>
    private void OnCollisionEnter2d(Collision2D collision)
    {
        // check if the player has collided with the ball_ground
        if (collision.gameObject.tag == "ball_ground")
        {
            this.hasBall = true; // set the flag to true
            Destroy(collision.gameObject); // destroy the ball ground object
        }
    }

    /// <summary>
    /// Set the flag to true if the player has the ball
    /// </summary>
    /// <param name="hasBall">bool hasBall</param>
    public void Set(bool hasBall)
    {
        this.hasBall = hasBall; // set the flag to true
    }

    /// <summary>
    /// Get the flag to true if the player has the ball
    /// </summary>
    /// <returns>bool hasBall</returns>
    public bool Get()
    {
        return hasBall;
    }
}
