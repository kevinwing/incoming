# AI

Unity ball Prefab

This is the ball projectile that the AI's will shoot at the player. The player fires a projectile called
"ball_p" that is identical in every way but name. This was done to avoid self-collsion issues with the player and AIs
sharing the same ball prefab. Both prefabs use the same "ball" script.

Operation:
- On start, the entity instantiating the ball will pass a target variable into the ball script. If the parent object is an AI,
   It will recieve the player as a target. If the parent object is the player, it will pass null in as a target, and so the ball will instead
   fire off in whatever direction the player's aiming widget is rotated.
- After the ball launches it will change tag to "ball_ground" either afer 1 second of flight or when it hits an entity or an obstacle, whichever
   happens first.
- Upon receiving this change to its tag, the ball will freely roll around the arena in an inert state until it is "recovered" by and AI or the player,
   at which point it will despawn.