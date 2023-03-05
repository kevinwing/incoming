using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AICoverPoints
{
    // A Test behaves as an ordinary method
    [Test]
    public void NavTest()
    {
        //Arrange AI ref
        var gObject = new GameObject();
        var AI = gObject.AddComponent<AI_square>();

        //Arrange sizes
        GameObject[] all = {};
        all = GameObject.FindGameObjectsWithTag("cover");
        int length = all.Length - 1;
        int expected = AI.getIndex();
        
        //Act
        AI.reIndex();

        //Assert
        Assert.IsTrue(expected >= 0 && expected <= length);
    }
}
