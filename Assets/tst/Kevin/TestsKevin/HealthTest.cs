using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthTest : MonoBehaviour
{
    [Test]
    public IEnumerator playerTakes99Damage()
    {
        var obj = new GameObject();
        var player = obj.AddComponent<Player>();
        player.setHealth(100);
        player.TakeDamage(99);

        Assert.AreEqual(1, player.getHealth());
        yield return null;
    }

    [Test]
    public IEnumerator playerTakes101DamageAndDies()
    {
        GameObject obj = new GameObject();
        obj.AddComponent<Player>();
        Player player = obj.GetComponent<Player>();
        player.setHealth(100);
        player.TakeDamage(101);


        Assert.AreEqual(-1, player.getHealth());
        yield return null;
    }

    [Test]
    public IEnumerator playerTakes100DamageAndDies()
    {
        GameObject obj = new GameObject();
        obj.AddComponent<Player>();
        Player player = obj.GetComponent<Player>();
        player.setHealth(100);
        player.TakeDamage(100);

        Assert.AreEqual(0, player.getHealth());
        yield return null;
    }

        [Test]
    public IEnumerator checkPlayerIsDead()
    {
        GameObject obj = new GameObject();
        obj.AddComponent<Player>();
        Player player = obj.GetComponent<Player>();
        player.setHealth(100);
        player.TakeDamage(100);

        Assert.AreEqual(false, player.isDead());
        yield return null;
    }
}
