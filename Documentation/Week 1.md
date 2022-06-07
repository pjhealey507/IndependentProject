Builds: 1 + 2 - Player Movement, Rewind, Shooting, Object Pooling
Packages: PlayerMovementRewind, PlayerShootObjectPool

For week 1 I created the prototype of the main mechanic, rewind.
The player's actions are executed via subclasses of the Command
base class, usually Move or Wait. After these actions are 
executed, they are stored in a Stack. When the player holds the 
rewind button, the actions are popped from top to bottom and the
reverse of the action is executed. There is a singleton called 
RewindManager which is responsible for knowing whether or not the
player is rewinding and executing the reverse of the commands.

The player also has the ability to shoot projectiles which will 
also rewind when the player is holding the rewind button. Both 
the player and the bullets are subclasses of RewindableObject. 
