# acromag-montecarlo
An attempt to make an AI for the acromage card game based on monte carlo tree simulation


-----

When I wrote this code, only I and god knew what's going on.   
Now only god left.

------

Theorethically, this is an attempt to make an AI based on a monte carlo tree simulation. Unfortunately, it has failed miserably, because the tree became very very very very wide and very very very deep pretty fast.  

At any point of the game you have about 12 choices you can make, and your opponent can make 12 choices after and so on and the game might or might not reach a conclusive decision within a finite amount of iterations.  

Perhaps a better approach to choosing the next action can be derived, based on some probabilistic formula, or w/e, instead of a random tree choice.

Besides, a human strategy in the game would be different, based on world state. A human might decide to push on attack when opponent's tower is low or build tower when he is close to winning range, or perhaps invest in resources if the game has just started. Perhaps a machine learning approach could be more interesting in this case.

--
Over and out