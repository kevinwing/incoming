using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BallVelTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void BallNullTargetTest()
    {
        //Arrange ref
        var gObject = new GameObject();
        var ball = gObject.AddComponent<ball>();

        //Assert
        Assert.IsTrue(ball.target == null);
    }

    [Test]
    public void BallTargetTest()
    {
        //Arrange ref
        var gObject = new GameObject();
        var ball = gObject.AddComponent<ball>();

        //Arrange ref
        var gObject2 = new GameObject();
        var pl = gObject2.AddComponent<AI_player>();

        ball.target = pl.gameObject;

        //Assert
        Assert.IsTrue(ball.target != null);
    }
}