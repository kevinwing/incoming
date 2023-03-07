using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class movement_test
{
    [Test]
    public IEnumerator moveAlongXAxisHorizontalInput()
    {
        Player player = new Player();
        player.pSpeed = 1f;

        yield return null;

        Assert.AreEqual(1, player.transform.position.x, 0.1f);
    }

    [Test]
    public IEnumerator moveAlongYAxisVerticalMovement()
    {
        var player = new Player();
        player.pSpeed = 1f;

        yield return null;

        Assert.AreEqual(1, player.transform.position.y, 0.1f);
    }
}