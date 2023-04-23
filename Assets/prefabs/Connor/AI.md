# AI

Unity AI Prefab

This is the basic AI I've implemented to fight the player in this game. It utilizes a Private Class Data
deisgn structure to keep the health variable closely guarded so it is not unintentionally edited. The actually prefab
is called "AI_square" because it was originally just a square. The "AI_square" inherits from the "AI" class, which also contributes
to the "AI_boss" entity the player fights at the end of the game.

Operation:
- The AI is spawned into the arena with a "dodgeball in hand" (hasBall boolean is set to true)
- The AI will randomly decide on a coverpoint to navigate to to try and shield itself from the player,
   choosing new ones as it reaches previous ones
- While the AI is navigating between cover points, it will attempt to hit the player with the ball it has
   (setting the hasBall boolean to false in the process)
- Once the AI has lost its ball, it will find the nearest free-rolling ball on the ground and navigate over to it to
   "pick it up" (despawn the ground ball and set hasBall boolean back to true)

The AI will repeat this cycle until it is struck down by the player or the player is struck down