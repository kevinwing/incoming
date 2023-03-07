using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DamageTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void DamageTestCheckWithinBounds()
    {
        //Arrange
        var expected = 10;
        var gObject = new GameObject();
        var P1 = gObject.AddComponent<PlayerHealth>();
        P1.SetHealth(100);
        

        //Act
        P1.DoDamage(90);



        //Assert
        Assert.AreEqual(expected, P1.GetHealth());
    }

    [Test]
    public void DamageTestLowerBound()
    {
        //Arrange
        var expected = 0;
        var gObject = new GameObject();
        var P1 = gObject.AddComponent<PlayerHealth>();
        P1.SetHealth(100);
        

        //Act
        P1.DoDamage(110);



        //Assert
        Assert.AreEqual(expected, P1.GetHealth());
    }

    [Test]
    public void DamageTestUpperBound()
    {
        //Arrange
        var expected = 100;
        var gObject = new GameObject();
        var P1 = gObject.AddComponent<PlayerHealth>();
        P1.SetHealth(100);
        

        //Act
        P1.DoDamage(-10);



        //Assert
        Assert.AreEqual(expected, P1.GetHealth());
    }




    [Test]
    public void DamageTestUpperBound99()
    {
        //Arrange
        var expected = 100;
        var gObject = new GameObject();
        var P1 = gObject.AddComponent<PlayerHealth>();
        P1.SetHealth(99);
        

        //Act
        P1.DoDamage(-10);



        //Assert
        Assert.AreEqual(expected, P1.GetHealth());
    }



    [Test]
    public void DamageTestUpperBoundFive()
    {
        //Arrange
        var expected = 0;
        var gObject = new GameObject();
        var P1 = gObject.AddComponent<PlayerHealth>();
        P1.SetHealth(5);
        

        //Act
        P1.DoDamage(10);



        //Assert
        Assert.AreEqual(expected, P1.GetHealth());
    }
}
