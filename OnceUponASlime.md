# Das-My-Slime
START SCENE
Start the game through StartMenu scene. The main game is located in the scene Main_Game2.

HOW TO PLAY
Move the slime with the WASD keys or arrow keys. Press space bar to jump.
Goal of the game is to return the slime princess to the castle before the clock reaches 00:00.

The enemy Spider & Dragons have animations controlled by state machines and will attack the slime princess.
Each time the slime princess is hit she will lose a heart in the heart UI and shrink down in size. 
If the player jumps on the spider's hitbox twice or hits it with a projectile twice the spider will die.

There is a Slime Bunny AI that guides the princess towards the castle and helps fight enemies. If she goes off path, the bunny will appear and guide the player.

The player can pickup vegetables, candy and slime blobs.
Collecting slime blobs will cause the player to grow larger and gain a heart. Player can have maximum six hearts.
If the player picks up a candy or vegetable it will be added to the inventory. 
Press C to use the candy as a projectile or V to eat the vegetable and get a speed boost.

The player can use the projectile to shoot the dragons and kill them. Hitting a dragon three times will kill the dragon. The dragon shoots fire which can cause the player to lose hearts. The player must kill two dragons to reveal a key. The key must be collected and is necessary to allow entry to the castle to win the game.

The player will need to cross a river. If she falls into the river, she will die, regardless of how many hearts she has left. Near the castle there are moving platforms that the player must jump across to climb the mountain and reach the castle.

If the princess loses all her hearts a "YOU LOSE" screen will appear.
If the princess enters the castle a "YOU WIN" screen will appear.

Libraries Used:
Kawaii Slime: https://assetstore.unity.com/packages/3d/characters/creatures/kawaii-slimes-221172
Spider: https://assetstore.unity.com/packages/3d/characters/animals/insects/spider-polygon-221108
Dragon: https://assetstore.unity.com/packages/3d/characters/creatures/dragon-the-soul-eater-and-dragon-boar-77121
Fire: https://assetstore.unity.com/packages/essentials/tutorial-projects/unity-particle-pack-127325
