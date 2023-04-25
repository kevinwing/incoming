using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class PlayerTests
{
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
        playerObj.AddComponent<Collider2D>();

        var ballObj = new GameObject();
        ballObj.AddComponent<Collider2D>();
        ballObj.tag = "ball_ground";

        var playerPickupBall = playerObj.AddComponent<PlayerPickupBall>();
        bool initialHasBall = playerPickupBall.HasBall();

        // Act

        playerObj.GetComponent<Collider2D>().SendMessage("OnCollisionEnter2D", ballObj.GetComponent<Collider2D>());

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
        Quaternion initialBallRotation = playerThrow.ballTransform.rotation;
        playerThrow.transform.rotation = initialBallRotation;

        // Act
        playerThrow.HandleShooting();
        Vector3 finalBallPosition = playerThrow.ballTransform.position;

        // Assert
        Assert.AreEqual(initialBallPosition, finalBallPosition);
    }

    [Test]
    public void moveAlongXAxisHorizontalMovement()
    {
        var obj = new GameObject();
        var player = obj.AddComponent<PlayerMove>();
        player.SetSpeed(1f);

        // yield return null;

        Assert.AreEqual(1, player.transform.position.x, 1f);
    }

    [Test]
    public void moveAlongYAxisVerticalMovement()
    {
        var obj = new GameObject();
        var player = obj.AddComponent<Player>();
        player.setSpeed(1);

        // yield return null;

        Assert.AreEqual(1, player.transform.position.y, 1f);
    }
}
