## Suggested Build Outline:

1. Establish a basic story and map (draw your map out)
2. Pull down the project and complete initial setup by satisfying all the interfaces ('implement interface')
3. In Game.Setup() create all your rooms and items
4. Your rooms will have to have a dictionary of 'exits' where the key is the exit direction and the value is the room that it exits to, add that to the Room class
5. Back in setup, establish the exits for each room
    - Room1.Exits.Add("east", Room2)
    - Room2.Exits.Add("west", Room1)
    - Room2.Exits.Add("north", Room3)
    - Room3.Exits.Add("south", Room2)
6. Create your items & add them to the Items list within the room they belong to.
7. At the end of setup be sure to set the CurrentRoom to whichever room the player should start in.
8. On the room class create a method to handle changing rooms. This method should return a room if one was found at that exit.
9. Create a similar method on the room for returning Items if the user used the 'take' action.
10. Back in the Game class, create methods for:
    - Look (returns the current room description)
    -  Quit (changes a global 'playing' variable to false)
    - Help (prints a list of usable commands)
11. Set Up your game loop in a method called Play
    -  This method should start by running Setup() before starting the loop
    -  In the while(playing) loop, prompt the user for input and take in user input
    - Evaluate that input on a switch to determine what action to run
      -  Go: runs the method you created to move from room to room
      - Take: attempts to move an item from the room list into the player inventory
      - Use: You will need to write a method on how to handle using the item
      - Look: run the look method
      - Help: run the health method
      - Quit: run the quit method.
12. In Game, Create an EndGame method to run when the player reaches a certain point in the game they have succeeded or lost
