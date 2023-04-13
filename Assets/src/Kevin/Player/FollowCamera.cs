// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; // reference for the Player transform

    private void Awake()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    // private void Start()
    // {
    //     player = GameObject.Find("Player");
    // }

    // Called when physics events occur
    // private void Update()
    private void FixedUpdate()
    {
        // change position of the camera relative to the position of the Player
        // transform.position = player.transform.position + new Vector3(0, 1, -10);
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
