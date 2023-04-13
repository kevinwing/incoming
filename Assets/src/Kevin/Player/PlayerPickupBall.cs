using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupBall : MonoBehaviour
{
    private bool hasBall = false;
    private void OnCollisionEnter2d(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball_ground")
        {
            this.hasBall = true;
            Destroy(collision.gameObject);
        }
    }

    public void Set(bool hasBall)
    {
        this.hasBall = hasBall;
    }

    public bool Get()
    {
        return hasBall;
    }
}
