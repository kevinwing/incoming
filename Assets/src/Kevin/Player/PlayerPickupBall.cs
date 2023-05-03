using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles pickup of the ball by the player
/// </summary>
public class PlayerPickupBall : MonoBehaviour
{
    public static SpriteRenderer ball; // reference to the ball game object

    void Awake()
    {
        ball = GameObject.Find("Ball").GetComponent<SpriteRenderer>(); // get the ball game object
        ball.enabled = false; // disable the ball game object
    }

    /// <summary>
    /// Check if the player has collided with the ball ground and set the flag to true if the player has collided with the ball ground. Destroy the ball ground object if the player has collided with the ball ground
    /// and Set the
    /// </summary>
    /// <param name="collision">The Instance of the collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Collision detected");
        // check if the player has collided with the ball_ground
        if (collision.gameObject.CompareTag("ball_ground") && !Player.hasBall)
        {
            Player.hasBall = true; // set the flag to true
            ball.enabled = true; // enable the ball game object
            Destroy(collision.gameObject); // destroy the ball ground object
        }
    }

    public bool HasBall()
    {
        return Player.hasBall;
    }

}
