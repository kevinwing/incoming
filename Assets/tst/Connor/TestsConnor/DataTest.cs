using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DataTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void DataClassTest()
    {
        //Arrange
        var expected = 10;
        var gObject = new GameObject();
        var AI = gObject.AddComponent<AI_square>();
        AI.Awake();

        //ACT
        var aiData = AI.GetAIData();


        //Assert
        Assert.IsNotNull(aiData);
    }
}
