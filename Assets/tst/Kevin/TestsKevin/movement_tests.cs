using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class movement_test
{
    [Test]
    public IEnumerator moveAlongXAxisHorizontalMovement()
    {
        var player = new Player();
        player.setSpeed(1);

        yield return null;

        Assert.AreEqual(1, player.transform.position.x, 1f);
    }

    [Test]
    public IEnumerator moveAlongYAxisVerticalMovement()
    {
        var player = new Player();
        player.setSpeed(1);

        yield return null;

        Assert.AreEqual(1, player.transform.position.y, 1f);
    }
}