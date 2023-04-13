using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform playerTransform; // reference for the Player transform

    private void Awake()
    {
    }

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    // Called when physics events occur
    void FixedUpdate()
    {
        // change position of the camera relative to the position of the Player
        this.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, this.transform.position.z);
    }
}
