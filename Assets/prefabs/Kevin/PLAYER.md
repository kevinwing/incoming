# Player
The Player functionality is divided into several domain specific scripts.
- Player: properties and methods pertaining to the player itself. example: health, is_dead
- PlayerAim: rotating the Aim child object to face the mouse cursor
- PlayerMove: perform move actions on the player as well as animations based on movement/idle
- PlayerThrow: throw ball in direction of where the player is aiming
- PlayerPickup: detect collision with grounded ball and 'equip' ball