# Shrink Racer

**_Developed In:_** Unity

**_Genre / Theme:_** Endless Corridor Style Shooter

**_Features:_**

Multi-Platform

The game can be played on both PC and Android. The controls for the game on PC is mouse
movement, and screen touch on Android

Core Game Mechanic:

The core mechanic of my game is a car that’s fuel depletes, and it drives forward. This fuel
depletion is visually represented by the shrinking of the player and the fuel bar at the top of the
screen. The cars fuel can be refilled by collecting fuel cans which are randomly spawned on the
road. If you let the car shrink too much, it breaks down and the game ends.

The car moves forward down the road itself, but the player must control its side-to-side
movement.

Power Ups:

The game contains different types of randomly spawning pickups, such as ammo refills and
speed boosts. These can be collected by driving through them.

Enemies:

The car is equipped with a turret on the roof, this turret will shoot at a constant fire rate as long
as its ammo isn’t empty.

The player must also avoid bullets fired at it by randomly generated enemy turrets. The players
bullets can destroy the enemy turrets, but it cannot destroy the static obstacles. This forces the
player to move the car around the round, instead of just staying in the one place and shooting
everything in their path.

Obstacles:

There are two types of obstacles in my game: a solid cop car and a barrier.

If the player collides with either obstacle, they die however if the player is small enough, they can
go under the barrier instead of around it.


Controls:

On laptop/desktop, the player controls the car using their mouse, moving left and right to move
the car to the side.

On mobile, the player controls the car using their finger, swiping left and right.

## Difficulties Encountered

The biggest difficulty I encountered was the car clipping into the road. The reason I encountered
this bug in the first place is because, both the car and the road have colliders attached them.
While this wouldn’t normally be a problem, due to the odd shape of both the road and the car
model, both the car and road had box colliders attached to them instead a mesh collider,
making the car appear to be sitting exactly on top of the road and not hovering over it meant that
these two colliders were very close to each other, and if they did collide with each other, it would
cause the car to flip over.

How I went about fixing this problem was first to apply a physics material to the road that
essentially removed all friction between the car and the road. I also froze the cars rotation on all
planes and its transformation on the Y plane, stopping the car from flipping over or spinning out
if it did collide with the road.

I also tried to make sure the box colliders on the both the car and the road were as exact as
possible, with no unnecessary space between the edge of the collider and the model itself.

## Possible Improvements

If I had more time, I would have added different types of enemies and power ups. I also would
have refined the animations of the different models in the game.

I also would have put more time into the user interface and object models. As I was limited by
time and money, I only used the free assets I could find online. Given more time I would have
created my own models using a software such as Blender.


## Screenshots

Mobile

![Mobile](https://github.com/brendan-sadlier/Shrink-Racer/blob/master/Mobile.png)

Desktop
![Desktop]((https://github.com/brendan-sadlier/Shrink-Racer/blob/master/Desktop.png)


