using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Utils;

public class PlayerAim : MonoBehaviour
{
    private Transform aimTransform;
    // private Transform ballTransform;
    // [SerializeField] private GameObject Ball;
    // private Vector3 ballPosition;

    [SerializeField] private PlayerPickupBall playerPickupBall;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        // ballTransform = aimTransform.Find("Ball");
    }

    private void Update()
    {
        HandleAiming();
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = Utils.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    // private void HandleShooting()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         // Vector3 mousePostition = GetMouseWorldPosition();
    //         ballPosition = ballTransform.position;

    //         Instantiate(Ball, ballPosition, Quaternion.identity);
    //     }
    // }

    // private static Vector3 GetMouseWorldPosition()
    // {
    //     Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    //     vec.z = 0f;
    //     return vec;
    // }

    // private static Vector3 GetMouseWorldPositionWithZ()
    // {
    //     return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    // }

    // private static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    // {
    //     return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    // }

    // private static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPostion, Camera worldCamera)
    // {
    //     Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPostion);
    //     return worldPosition;
    // }
}
