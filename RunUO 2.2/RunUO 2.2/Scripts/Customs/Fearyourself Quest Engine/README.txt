I've been here for a week now so you mustn't be hoping for a nice, polished, most probably bug free script.

But it's a start and I'll be using this thread to get your opinion on it and to have a place to update the project as it progresses...

With Daat99's help, comments, advice and source code (yeap, I did look into it to find inspiration on a few details), I've finished this nice little Quest System I've been doing.

What is done :

- Logging System that lets a quest know what quests have been done or are being done.
Each quest has four basic states :
- Accept (still doing it), Canceled, Finished, Refused

- Basically you can take any quest you already have, add two or three lines and then have it logged in, which will give the admin a way to see who's doing what (when finished)

This enables a quest script to decide what to do...

- It also allows another quest to know what the player did on a certain quest. This can give place to complicated quests that were difficult to put in place before (in my opinion)...

Following Daat99's advice, I put these states into a class that can be inherited so the quester can add information (did you take this item or that item for example...).

- A basic Bunny Attack quest (taking back the first example quest I did) using this new system that is now redoable as many times as you want...

- A more complicated quest, the ChainOfMammals Quest :

1) Alfred asks you to take out 5 rats but then tells you that Brian has your reward.
2) Brian asks you to take out 4 JackRabbits and then go see Charly for the reward
3) Charly gives you your reward and IF you did the BunnyAttackQuest, he'll tell you to go see David.
4) David gives you twice gold if you have done both quests...

Please note : These quests are example quests. They aren't made to work 100% if you start doing things you're not supposed to... It's not their purpose.

What is delaying the release as a full Script for the admin and a tutorial explaining it all for the programmer ?

- Testing of the whole system to make sure it checks out
- Once the tests are made, I'll be highly commenting the code and making four tutorials (if people are interested of course) :
- For the admin, the TODO list to put up the system
- For the casual scripter, so that he knows what should be where and how it all works
- For the casual programmer, so that he knows how he should be programming a quest if he wants to invent something
- For the hardcore game programmer, so he can have an insight on how the whole quest system works...

If you have a simple example quest you'd like to see done, mp me and I'll consider doing it as part of the package
The BunnyAttack quest represents the basic "Go kill these dudes" but I'll be doing the "Go fetch me this" quest as well...

What is planned for a future release

- All this information is nicely stored and I'll be doing a ControlCenter (like Daat99's most probably) for admins to check out what is being done and by whom but also for players to see what they've done, etc.

- Since apparently you can only be doing one quest at a time in UO (or am I mistaken ?), I've been thinking of extending this system to allow multiple questing. All the player would have to do is go back to the ControlCenter to choose what quest he wants to finish...

- A few more explained quests to help out scripters...

Ok so is the release you've made safe ?

- Absolutely not, test it only on your test shard. You'd be crazy to put this on a production shard in its actual state.

- This release is to give people a first look at the code so if they want to copy-paste like crazy they can.

- It will also let me know if there are things you'd like to see in the system so I know now what the needs are/can be...

Jc


PS: As far as I can see, the quests I made are safe and work properly. If you notice anything, then keep me posted...