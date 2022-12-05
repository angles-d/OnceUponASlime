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

WORK DISTRIBUTION
Angela:
-Modeled candy, vegetable, castle
-Designed UI buttons & background
-Implemented audio manager
-Created spider enemy (code, logic, animation)
-Created dragon enemy (logic, player interaction)
-Coded player movement and grow/shrink logic & animation
-Created platform prefab
-Implemented Heart System for Player

Scripts:
-SpiderController.cs
-PlayerController.cs
-HitBoxController.cs
-DragonController.cs
-HeartController.cs
-PlayerEnterTerrorritory.cs
-PlatformController.cs
-AudioManager.cs
-Controller.cs
-PlayerMovement.cs

Prefabs:
-root_Spider
-Big_Dragon_Root
-small_Dragon_Root
-Platform
-Heart UI

Neha:
-created scene of main game
-implemented trees and terrain
-assisted in animations for slime player bounce
-created river rocks 
-assisted in rabbit animation
-implemented initial castle 
-updated scene terrain making mountains and other features less sharp
-implemented UI state screens (start, pause, stop)
-implemented audio files as well as sound effects for win state, river death, 
and assisted with audio help
-assisted with projectile functions
-key collection sound file
-initial slime trail implementation
-implemented platforms to get to the castle as well as across the river
-sky box/clouds implementation

Scripts: 
-StartGame.cs
-QuitGame.cs
-PauseGame.cs
-SlimeTreeCollision.cs
-Bullet.cs
-winSound.wav
-keyCollected.wav
-water_splash_sound.mp3
-sky files

Prefabs/scene work/animations:
-trees prefab
-rocks prefab
-terrain build
-initial castle prefab
-platform prefab- platform moving across the river
-projectile prefab
-tree slime animation
-slime bounce animation
-Bullet / projectile prefab
-sky box files as well as scene updates for the clouds


Anjum:
-Implemented start screen
-Implemented logic for collectables (vegetables, candies, slime blobs)
-Implemented inventory updating for vegetables and candies
-Implemented size increase depending on collectables
-Assisted in slime bounce animation
-Implemented projectiles
-Implemented dragon/projectile collision
-Added dragon colliders
-Implemented platforms and player/platform interaction logic
-Added slime die (melt) animation

Scripts:
-HowToPlay.cs
-PauseGame.cs
-Projectile.cs
-ProjectileShooter.cs
-QuitGame.cs
-Rotator.cs
-SlimeTrigger.cs
-StartGame.cs
-CollectCandy.cs
-CollectVeggie.cs
-ScoreCandy.cs
-ScoreVeggie.cs
-PlatformController.cs
-PlayerMovement.cs
-PlayerController.cs

Prefabs/Animations:
-Candy
-SlimeBlobs
-ThrowingProjectiles
-candyCount
-veggieCount
-HowToPlayButton
-Menu
-QuitGameButton
-StartGameButton
-Platform
-Carrot
-Vegetable
-ThrowingProjectile

Rutika:
-Implemented Inventory
-Placed Collectables into Scene
-Implemented collectables to be added to inventory on collision
-Added animations to collectables (rotation)
-Created model for river
-Added river model to scene with water material asset
-Added river implementation
-Assisted with timer and light
-Added dragon animations
-Key implementation & dragon death checking
-Added sound effects such as key collection

Scripts:
-PlayerController
-TimeController
-PlayerMovement
-Rotator
-StartGame
-SlimeTrigger

Prefabs:
-SlimeBlobs
-Big_Dragon
-Small_Dragon
-Candy 
-Veggie
-River

Sinduja:
-Implemented AI Rabbit logic for player to follow using state machine
-Added rabbit animation
-added 'follow me alert' in UI
-Added directional sunlight and moonlight
-Added timer
-Implemented day-night cycle background lighting change
-Added cut scene with the backstory
-added speechbubbles, start, quit, skip to play buttons
-Added how to play scene with play and back button
-Added terrain walls of the world


Scripts/Scenes:
-TimeController.cs
-Timer.cs
-RabbitState.cs
-RabbitStateManager.cs
-RabbitIdle.cs
-RabbitHelp.cs
-RabbitAlert.cs
-HowToPlayScene.unity
-CutScene.unity
-colliderwalls.cs
-cutscene_invoke.cs
-disable_airabbit.cs
-HowToPlay.cs
-Textanim_story.cs

Prefabs/Animations:
-AIRabbit
-Rabbit jump animation
-Timer UI 
-Ambient light change in sunlight and moonlight animations
-Cut scene animations of type writing text
-how to play background
-Sunlight
-Moonlight
-follow me alert
