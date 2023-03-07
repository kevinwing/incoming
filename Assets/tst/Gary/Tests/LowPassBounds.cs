using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class LowPassBounds
{
    // A Test behaves as an ordinary method
    [Test]
    public void FreqCheckLowerBounds()
    {
        //Arrange
        var expected = 120;
        var gObject = new GameObject();
        var P1 = gObject.AddComponent<AudioManager>();

        //Act
        float frequency = P1.SetLowPass(5);  // Setting lowpass below lower bound of 120hz

        //Assert
        Assert.AreEqual(expected, frequency);
    }
    // A Test behaves as an ordinary method
    [Test]
    public void FreqCheckUpperBounds()
    {
        //Arrange
        var expected = 22000;
        var gObject = new GameObject();
        var P1 = gObject.AddComponent<AudioManager>();

        //Act
        float frequency = P1.SetLowPass(30000); //  Setting lowpass above upper bound of 22000hz

        //Assert
        Assert.AreEqual(expected, frequency);
    }
/*
        // A Test behaves as an ordinary method
   [Test]
    public void FreqCheckMath()
    {
        //Arrange
        float health = 30;
        float expected = health * Mathf.Pow((health/10), 2.5f);
        var gObject1 = new GameObject();
        var P1 = gObject1.AddComponent<AudioManager>();


        //Act
        float actual = P1.SetLowPass(health);



        //Assert
        Assert.AreEqual(expected, actual);
    }
*/

}
