# Player Prefab
The player prefab is comprised of many different components

## Transform
The Transform component defines the position, rotation, and scale of an object in the Unity scene. It is a required component on all game objects in Unity.

## Sprite Renderer
The Sprite Renderer component is responsible for rendering 2D sprites in the Unity scene. It takes a reference to a sprite asset, and allows for additional customization of the sprite's rendering, such as color tinting and flipping.

## Capsule Collider
The Capsule Collider component is a 3D collision shape that is often used for character controllers and other game objects that require more complex collision detection. It can be oriented along any of the three axes and its height and radius can be adjusted to fit the object's shape.

## Rigidbody2D
The Rigidbody2D component is responsible for controlling the physics of 2D game objects in Unity. It allows for the application of forces and torques, as well as the simulation of collisions and other physical interactions.

## Animator
The Animator component is used to create animations for game objects in Unity. It takes an animation asset, and can be used to control the playback of that animation, as well as to blend between different animations and trigger events during animation playback.

# Class Components
The Player prefab follows the Component Pattern. The Component Pattern is used when a single object such as our Player, spans multiple domains. In the Component design pattern, each class has a single focus, such as Movement or Shooting, and each class does not require knowledge of any of the other classes.


## Player

The Player class represents the player in the game. It is responsible for initializing the player's components and setting up its initial state.

#### Fields

- `speed`: The speed at which the player moves.

#### Methods

```C#
Move() // Moves the player based on input received from the PlayerMove class.
Rotate() // Rotates the player's aim based on input received from the PlayerAim class.
```
## PlayerAim

The PlayerAim class is responsible for controlling the aim of the player's throw. It rotates the player's aim based on input received from the mouse.

#### Fields

- `aimTransform`: The transform of the player's aim object.
- `rotationSpeed`: The speed at which the aim object rotates.

#### Methods
```C#
RotateAim() // Rotates the aim object based on the mouse position.
```
## PlayerMove

The PlayerMove class is responsible for controlling the movement of the player. It moves the player based on input received from the keyboard.

#### Fields

- `speed`: The speed at which the player moves.
- `rigidbody`: The player's rigidbody component.
- `movement`: The player's movement vector.
- `transform`: The player's transform component.
- `_animator`: The player's animator component.

#### Methods

```C#
ProcessInputs() // Processes input received from the keyboard.
Move() // Moves the player based on the processed input.
Animate() // Animates the player's movement based on the processed input.
```
## PlayerPickupBall

The PlayerPickupBall class is responsible for allowing the player to pick up the ball when it collides with the player. It sets the hasBall field to true and destroys the ball object.

#### Fields

- `hasBall`: A boolean indicating whether the player has the ball.

#### Methods
```C#
Set() // Sets the hasBall field to the specified value.
Get() // Returns the hasBall field.
```
## PlayerThrow

The PlayerThrow class is responsible for allowing the player to throw the ball. It instantiates a new ball object when the player clicks the mouse button.

#### Fields
- `aimTransform`: The transform of the player's aim object.
- `ballTransform`: The transform of the ball object.
- `ball`: The ball prefab.
- `playerPickupBall`: The PlayerPickupBall component attached to the player.
#### Methods
```C#
HandleShooting() // Instantiates a new ball object when the player clicks the mouse button.
```
# Extra
## Utils

The Utils class provides utility functions for getting the mouse position in world space.

```c#
public static Vector3 GetMouseWorldPosition()
```

**Returns**: The mouse position in world space as a Vector3 with z-coordinate set to 0.

```c#
public static Vector3 GetMouseWorldPositionWithZ()
```
**Returns**: The mouse position in world space as a Vector3 with z-coordinate preserved.

```c#
public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
```
**Parameters**:

- `worldCamera`: The Camera to use for converting the screen position to world space.

**Returns**: The mouse position in world space as a Vector3 with z-coordinate preserved.

```c#
public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPostion, Camera worldCamera)
```
**Parameters**:

- `screenPostion`: The screen position to convert to world space.
- `worldCamera`: The Camera to use for converting the screen position to world space.

**Returns**: The mouse position in world space as a Vector3 with z-coordinate preserved.