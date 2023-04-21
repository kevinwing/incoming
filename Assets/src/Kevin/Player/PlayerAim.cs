using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Utils;

/// <summary>
/// Handles the aiming of the player
/// </summary>
public class PlayerAim : MonoBehaviour
{
    public Transform aimTransform; // reference to the aim transform

    [SerializeField] private PlayerPickupBall playerPickupBall; // reference to the player pickup ball script

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        aimTransform = transform.Find("Aim"); // find the aim transform
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        Aim(Utils.GetMouseWorldPosition()); // handle aiming
    }

    /// <summary>
    /// Handles the aiming of the player by rotating the aim
    /// transform to face the mouse position in world space
    /// </summary>
    public void Aim(Vector3 mousePos)
    {
        Vector3 mousePosition = mousePos; // get the mouse position in world space

        // get the direction from the player to the mouse position
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        // get the angle from the player to the mouse position
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        // rotate the aim transform to face the mouse position
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }
}
