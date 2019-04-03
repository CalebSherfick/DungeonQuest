# Console Game Checkpoint

### The Setup

As you begin working on a console game the basic requirements of any good console game will allow users to:
  - Move about a set of rooms
  - Get a description of the room they are in
  - Get Help - Shows a list of all available commands
  - Take Items
  - Use Items
  - Give Up 
  
To help you out with some of these basic features will notice that you already have some interfaces that have been built. These interfaces are designed to help ensure you implement the basic requirements of a console game. 

### Step 1 -  Satisfy the Interfaces 

To satisfy the interfaces you will need to ensure that your classes implement all of the features of the provided interfaces... You cannot remove anything from any of the interfaces. 
  The Basic Features of the game:
  - `Go <Direction>` Moves the player from room to room
  - `Use <ItemName>` Uses an item in a room or from your inventory
  - `Take <ItemName>` Places an item into the player inventory and removes it from the room
  - `Look` Prints the description of the room again
  - `Inventory` Prints the players inventory
  - `Help` Shows a list of commands and actions
  - `Quit` Quits the Game

### Step 2 - Control the Game Loop

We have provided a basic story and map if you are not creative or simply don't want to spend your time thinking of a story to play your game. Following the provided story is not required however creating some sort of experience is. 

Your Game must implement the following features
  - At least 4 rooms
  - At least 1 usable item
  - At least 1 item that can be taken (can be the same as the usable item)
  - At least 1 room that changes based on an item use
  - When the player enters a room they get the room description
  - Players can see the items in their inventory
  - Players lose the game due to a bad decision
  - Players can win the game
  
  
 ## Functionality: 
 - Player input must be seperated into `command` and `option` 
  - go north
  - take key
  - use :banana: 
 - Players can move room to room with the `go <direction>` command
 - Players can `use` items to change the state of the room (use key or use light)
 - Items exist for the player to `take` from rooms (not required for these to be used in a room)
 - `quit` ends the game
 - At least 4 rooms, 1 usable item, and 1 takeable item
 - Players can lose the game due to a bad decision
 - The game is winnable 

## Visualization: 
 - `help` Provides the user a list of commands for your game
 - `look` Re-prints the room description
 - `inventory` prints a list of the items in the players inventory
 -  When the player enters a room they get the room description
  
### BONUS IDEAS - Some enhancing features
- Try changing the console color or adding some beeps for dramatic effect
- Clear the console when appropriate
- The user should know when its their turn try formatting the users input with something like this everytime its the users turn to type
  - What do you do: __________________ // <- Their Answer on the same line
- Add some riddles or puzzles for users to solve to get from room to room

### Finished?
When You are finished please submit the url for your github repo to the gradebook.
