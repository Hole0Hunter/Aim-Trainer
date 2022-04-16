
# Aim Trainer
An aim trainer developed as a part of my course work, Human Computer Interaction from scratch using Unity game engine. 

## Features:
### Training Tasks:

 1. **Flickshot**: Three targets will spawn randomly across an Invisible grid on the screen. Kill one and another spawns so there are always three targets on screen. Helps the user train their flicking skills.
 *Scoring Metrics*: +500 for shooting an orb, -200 if missed.
 2. **Tracking**: An orb strafes back and forth at random testing your ability to track movement and keep your crosshair on the target. Helps the user train their tracking skills.
 *Scoring Metrics*: +500 on hovering over an orb, -200 if missed.
 3. **ReactionTime**: This task focuses on measuring and training your visual detection time for targets across the visual field. The screen turns Blue from Orange randomly at some instance, and your Instructions are to respond as soon as the blue screen appears. If you respond when no blue screen is present, you will be penalized and there will be a short delay before targets may spawn again. Helps the user train their reaction time.
 *Scoring Metrics*: If the reaction time of the person comes out to be 't' in milliseconds, the score awarded would be 100000/(t+1) awarding a person with less reaction time a high score while a high reaction time a less score. -200 if missed.
 
### Quality of Life
 1. The player can adjust mouse sensitivity.
 2. The player can choose to turn audio ON/OFF.

## Further Work
### Add new tasks like:

 1. Microshot: Trains a user's precision. Similar to flickshot but the size of the orbs are much smaller hence need more precision.
 2. RandomTrack: In the usual Tracking, the orbs strafe to the in horizontal axis. In this task the orb can travel in curved paths, change directions to some random axis.

### Add new AI mechanics:
For now the target spawns are random. This can be changed by implementing algorithms which will detect patterns of user cursor movements and make the orb spawns more inclined towards the screen space where the user has trouble reaching to. This will help the user to focus on their weaknesses and improve on them.

### Quality of Life
 1. Add Background music
 2. Add new analysis system to help the user know his weaknesses.
 3. Allow the user to use their own SFX for background music or pop sounds when an orb is destroyed.

### Finally release it on Steam! :D
