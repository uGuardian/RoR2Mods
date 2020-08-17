# NoNanoBombGravity
Makes gravity for Artificer's Nano Bomb configurable.

Made at the request of Chum.

Currently does this by directly overriding AntiGravityForce.antiGravityCoefficient, and thusly will impact any other mods that call the monobehavior.
To the best of my knowledge Nano Bomb is the only thing in the game that actually uses this script, please @uGuardian on the modding Discord if you encounter any problems with this mod or have any suggestions!

#### Changelog

<b>1.1.0</b>:<br>
Configuration has been added, now you can make the gravity heavier, lighter, or even inverted if you really wanted.<br>
It's a counter-coefficient, so<br>
more-gravity⮜1⮜less-gravity