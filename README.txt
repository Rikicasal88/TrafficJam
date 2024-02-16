Hello, this is the Unity programming test README.
In here I am writing all the info you will need to know about the project, the how and why of some of the systems and the duration of the developemnt.

I am using Unity 2020.3.25f1


After the initial set up of the scene I decided to work on task 2 and 3. I initially used the Vector3.Dot but I didn't have all the info I was looking for.
So I checked online and I found Vector3.SignedAngle (https://docs.unity3d.com/ScriptReference/Vector3.SignedAngle.html). I decided to implenment this instead and it was exactly what I was looking for.
I gave an ACCELLERATION="2000 to all the cars because I needed a constant Speed, then I limited it via the MaxSpeed variable.  


I have never done a Particles before. I did tweak some in the past but never created one, so I decided to get some inspiration from this tutorial(https://www.youtube.com/watch?v=5Mw6NpSEb2o)

I created a sptireAtlas with all the used textures for the Particles in order to slighlty reduce the memory usage.
I checked the frame debugger and I saw that the PlayArea shadow was creating 6 more batches, so I baked the shadows of the PlayArea.

I also created an Indicator to help the player remembering what was the last selected point.
There is also an AudioManager that fires Audio Clip when the money are collected or when the Traffic collides with the Player.
In the Managers/GameManager in the scene there is a toggle for a drifting mode, if it is ON (my advice is to reduce the MaxSpeed of the Player to 10 in the SpawnableObjects),
I leave the physics do it's job and make the car drifiting a lot(super fun). 



1) Set up game board, game scene, camera and player car		/30min
2) Make car move forwards at a constant speed		/20min
3) Click to steer player's car towards the mouse click location		2h
4) Ensure player can't move outside of the playing area		/5min 
5) Randomly spawn money within the playing area		/1h 
6) The player can collect money by colliding into it		/10min 
7) Show player’s collected money total on screen		/20min 
8) Randomly spawning blue traffic		/1h 
9) Making traffic move, and removing cars that go off the board		/20min 
10) Detecting player collisions with blue traffic		/30min 
11) Implement and show game timer on screen		/15min 
12) Show Game Over message with score when timer expires		/20min 
13) Add a main menu screen with a Start button		/5min 
14) Go back to main menu after player has seen Game Over message		/10min 
15) Polish - Add particle effects to represent vehicle collisions		/30min 
16) Polish - Add particle effects when money is collected		/10min 
