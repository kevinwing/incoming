using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class movement_test
{
    [Test]
    public void moveAlongXAxisHorizontalMovement()
    {
        var obj = new GameObject();
        var player = obj.AddComponent<Player>();
        player.setSpeed(1);

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