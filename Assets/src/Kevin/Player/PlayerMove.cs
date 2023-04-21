using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the movement of the player by applying forces to the rigidbody component of the player object
/// </summary>
public class PlayerMove : MonoBehaviour
{
    private float _speed = 5f; // speed of the player
    private Rigidbody2D _rigidbody; // reference to the rigidbody component of the player object
    private Vector2 _movement; // direction of the player movement
    private Transform _transform; // reference to the transform component of the player object
    [SerializeField] Animator _animator; // reference to the animator component of the player object

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// This is where we get references to the components of the player object
    /// </summary>
    private void Awake()
    {
        this._rigidbody = GetComponent<Rigidbody2D>(); // get the rigidbody component of the player object
        this._transform = this.transform;   // get the transform component of the player object
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// This is where we process the player inputs and apply the movement
    /// to the player object by applying forces to the rigidbody component of the player object
    /// </summary>
    void Update()
    {
        ProcessInputs(); // process the player inputs
    }

    /// <summary>
    /// FixedUpdate is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        Move(); // move the player object
        Animate(); // animate the player object based on the movement direction
    }

    /// <summary>
    /// Process the player inputs and set the movement direction of the player object
    /// </summary>
    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // get the horizontal input axis value (left/right)
        float moveY = Input.GetAxisRaw("Vertical"); // get the vertical input axis value (up/down)

        this._movement = new Vector2(moveX, moveY).normalized; // set the movement direction of the player object based on the input axis values (normalized to 1)
    }

    /// <summary>
    /// Move the player object by applying forces to the rigidbody
    /// component of the player object based on the movement direction and speed of the player object
    /// </summary>
    private void Move()
    {
        // apply forces to the rigidbody component of the player object based on the movement direction and speed of the player object
        this._rigidbody.velocity = new Vector2(this._movement.x * this._speed, this._movement.y * this._speed);
    }

    /// <summary>
    /// Animate the player object based on the movement direction of
    /// the player object by setting the values of the animator
    /// parameters "Horizontal" and "Vertical" to the x and y components
    /// of the movement direction vector respectively and the value of the
    /// animator parameter "Speed" to the magnitude of the movement direction
    /// vector squared (sqrMagnitude)
    /// </summary>
    private void Animate()
    {
        this._animator.SetFloat("Horizontal", this._movement.x);
        this._animator.SetFloat("Vertical", this._movement.y);

        this._animator.SetFloat("Speed", this._movement.sqrMagnitude);
    }
}
