using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class PlayerTests
{
    [Test]
    public void TestPlayerMovement()
    {
        // Arrange
        GameObject playerObj = new GameObject();
        var playerMove = playerObj.AddComponent<PlayerMove>();
        playerMove._rigidbody = playerObj.AddComponent<Rigidbody2D>();
        float initialXPos = playerObj.transform.position.x;

        // Act
        playerMove.Move(2f); // Move right
        float finalXPos = playerObj.transform.position.x;

        // Assert
        Assert.Greater(finalXPos, initialXPos);
    }
    [Test]
    public void TestPlayerAimRotation()
    {
        // Arrange
        GameObject playerObj = new GameObject();
        PlayerAim playerAim = playerObj.AddComponent<PlayerAim>();
        playerAim.aimTransform = playerObj.transform;
        Vector3 aimTarget = new Vector3(1f, 0f, 0f);
        playerAim.Aim(aimTarget);
        float expectedAngle = 0f;

        // Act
        float actualAngle = playerObj.transform.eulerAngles.z;

        // Assert
        Assert.AreEqual(expectedAngle, actualAngle);
    }

    [Test]
    public void TestBallPickup()
    {
        // Arrange
        var playerObj = new GameObject();
        var ballObj = new GameObject();
        ballObj.tag = "ball_ground";
        var playerPickupBall = playerObj.AddComponent<PlayerPickupBall>();
        bool initialHasBall = playerPickupBall.HasBall();

        // Act
        playerObj.GetComponent<Collider2D>().SendMessage("OnCollisionEnter2D",
            new Collision2D {
                // gameObject = ballObj
            });

        bool finalHasBall = playerPickupBall.HasBall();

        // Assert
        Assert.IsFalse(initialHasBall);
        Assert.IsTrue(finalHasBall);
    }

    [Test]
    public void TestBallThrow()
    {
        // Arrange
        GameObject playerObj = new GameObject();
        GameObject ballPrefab = GameObject.Find("ball_p");
        var playerThrow = playerObj.AddComponent<PlayerThrow>();
        playerThrow.ballTransform = playerObj.transform;
        playerThrow.ball = ballPrefab;
        Vector3 initialBallPosition = playerThrow.ballTransform.position;

        // Act
        playerThrow.HandleShooting();
        Vector3 finalBallPosition = playerThrow.ballTransform.position;

        // Assert
        Assert.AreEqual(initialBallPosition, finalBallPosition);
    }
}
