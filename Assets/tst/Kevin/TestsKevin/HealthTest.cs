using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthTest
{
    [Test]
    public void playerTakes99Damage()
    {
        var obj = new GameObject(); // create empty game object
        var player = obj.AddComponent<Player>(); // add Player object to obj and get reference
        player.setHealth(100); // ensure player object health is at 100

        player.TakeDamage(99); // do less than 100 damage

        Assert.AreEqual(1, player.getHealth()); // should have 1 hitpoint left
    }

    [Test]
    public void playerTakesFatalHitHealthCheck()
    {
        var obj = new GameObject();
        var player = obj.AddComponent<Player>();
        player.setHealth(100);

        player.TakeDamage(100);

        Assert.AreEqual(0, player.getHealth());
    }

        [Test]
    public void playerTakesFatalHitIsDead()
    {
        var obj = new GameObject();
        var player = obj.AddComponent<Player>();
        player.setHealth(100);

        player.TakeDamage(100);

        Assert.AreEqual(true, player.isDead());
    }
}
