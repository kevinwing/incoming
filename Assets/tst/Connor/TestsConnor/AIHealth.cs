// using System.Collections;
// using System.Collections.Generic;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;

// public class AIHealth
// {
//     // A Test behaves as an ordinary method
//     [Test]
//     public void DamageTest()
//     {
//         //Arrange
//         var expected = 10;
//         var gObject = new GameObject();
//         var AI = gObject.AddComponent<AI_square>();
//         AI.setHealth(100);

//         //Act
//         AI.DoDamage(90);

//         //Assert
//         Assert.AreEqual(expected, AI.GetHealth());
//     }

//     [Test]
//     public void DamageTestHigh()
//     {
//         //Arrange
//         var expected = 100;
//         var gObject = new GameObject();
//         var AI = gObject.AddComponent<AI_square>();
//         AI.setHealth(100);

//         //Act
//         AI.DoDamage(-10);

//         //Assert
//         Assert.AreEqual(expected, AI.GetHealth());
//     }

//     [Test]
//     public void DamageTestLow()
//     {
//         //Arrange
//         var expected = 0;
//         var gObject = new GameObject();
//         var AI = gObject.AddComponent<AI_square>();
//         AI.setHealth(100);

//         //Act
//         AI.DoDamage(110);

//         //Assert
//         Assert.AreEqual(expected, AI.GetHealth());
//     }
// }
