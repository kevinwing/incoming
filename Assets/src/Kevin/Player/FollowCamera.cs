// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player; // reference to the Player

    private void Start()
    {
        this.player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        // change position of the camera relative to the position of the Player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
    }
}
