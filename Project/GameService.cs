using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool Questing { get; set; }


    public void StartGame()
    {
      Setup();
      Console.Clear();
      //   System.Console.WriteLine("You are a peasant in the Land of Ooo, and are looking to become a legendary adventurer like your idol, Billy the Hero.\nYou decide to do whatever it may take in order to accomplish a feat worthy of qualifying you as a notable hero.\nSince beginning your quest, you have been lifting rocks and pulling on tree branches in hopes of\ndiscovering a secret dungeon in the process. Today you have decided to quest for dungeons in the Enchiridion Mountains;\na forbidden land crawling with death and disease.");
      //   System.Console.WriteLine("");
      //   System.Console.WriteLine("In order to make your search easier, you decide to either only pull on branches, or to only lift rocks.\nWhich do you choose, (B)ranches or (R)ocks?");
      //   SearchStrategy();
      while (Questing)
      {
        Console.Clear();
        if (CurrentRoom.Name == "Left" && CurrentPlayer.Immune == false)
        {
          Console.Clear();
          System.Console.WriteLine("You attempt to go through the fire barrier and catch yourself on fire in the process. You burn up and die.");
          Questing = false;
        }
        if (CurrentRoom.Name == "Left" && CurrentPlayer.Immune == true)
        {
          Console.Clear();
          System.Console.WriteLine($"{CurrentRoom.Description}");
          System.Console.WriteLine("Do you wish to grab it?");
          string enter = Console.ReadLine().ToLower();
          if (enter == "y" || enter == "yes" || enter == "yeah" || enter == "of course" || enter == "hell yeah" || enter == "hell yes" || enter == "no duh" || enter == "for sure" || enter == "sure" || enter == "i guess" || enter == "yeet")
          {
            System.Console.WriteLine("As you approach the book, you step and trigger a pressure plate and see arrows fly toward you. With your newly gained powers, the arrows bounce off of you and fall to the ground. You grab the book to find it is Billy the Hero's diary on how he became a hero. With the power from the fountain and the knowledge from the book, you are well on your way to becoming a hero. Congratulations!");
            Questing = false;
          }
          else
          {
            System.Console.WriteLine("You decide to play it safe and do not take the book.");
          }
        }


        System.Console.WriteLine($"{CurrentRoom.Description}");
        System.Console.WriteLine("");
        System.Console.WriteLine("What would you like to do?");
        GetUserInput();

        //if current room is fireroom 
        //if CurrentPlayer.immune
        //win
        //else
        //DIe
      }
      //play again?
    }



    public void Setup()
    {
      //Create all Rooms
      //   Room start = new Room("Entry", "You stand in a very dark room. You see a faint glow in the distance coming from the North, in what you can only assume\nis another section of the dungeon.");
      //   Room middle = new Room("Middle", "There is a very noticable fire burning in a doorway leading to another room to the West. You can barely make out a few\nitems scattered around the room as the light flickers. As your eyes adjust, you see a closed door on the East side of\nthe room.");
      //   Room right = new Room("Right", "The room is pitch black. You are unable to see anything.");
      //   Room left = new Room("Left", "With the absence of the fire barrier, you are unable to see what lies before you.");
      Room start = new Room("Entry", "You notice this is the begininng of the dungeon, it is very damp and smells of mold. Being in this room makes you question your abilities.");
      Room middle = new Room("Middle", "There is a large burning fire blocking the entrance of a pathway to the East. To the West you see a heavy metal door that has accumulated years worth of rust.");
      Room right = new Room("Right", "There is a small fountain in the center of the room. It looks extremely elegant and seems odd to have been locked behind such a large door.");
      Room left = new Room("Left", "Before you is a dusty old book sitting atop an altar.");


      //Establish relationships
      start.AddExit(Direction.north, middle);
      //   middle.AddExit(Direction.east, right);
      middle.AddExit(Direction.south, start);
      //   middle.AddExit(Direction.west, left);
      right.AddExit(Direction.west, middle);
      left.AddExit(Direction.east, middle);

      middle.addLockedRoom("key", Direction.east, right);
      middle.addLockedRoom("fountain", Direction.west, left);

      Item key = new Item("Key", "An old fragile skeleton key.");
      //   Item torch = new Item("Torch", "Looks unused.");
      //   Item litTorch = new Item("Torch", "Flames dance at the end, radiating both heat and light.");
      //   Item sword = new Item("Dusty Sword", "Covered in dust and looks very old.");
      //   Item cleanSword = new Item("Billy's Sword", "A magical blade, feels like it could cut anything!");
      //   Item bucket = new Item("Bucket", "Just an ordinary wooden bucket.");
      //   Item filledBucket = new Item("Bucket", "A wooden bucket filled with water.");

      start.AddItem(key);
      //   middle.AddItem(bucket);
      //   middle.AddItem(torch);
      //   start.AddItem(sword);


      CurrentRoom = start;
      CurrentPlayer = new Player("Finn");
      Questing = true;

    }

    void SearchStrategy()
    {
      string strategy = Console.ReadLine();
      switch (strategy.ToLower()[0])
      {
        case 'b':
          Console.Clear();
          System.Console.WriteLine("After pulling on nearly 2,000 branches, you pull on your last branch of the day and hear a click as it pulls down\ntoward the ground. You notice a nearby boulder slowly moving to reveal the entry point of a dungeon. ");
          System.Console.WriteLine("");
          System.Console.WriteLine("Do you wish to enter the dungeon?");
          string enter = Console.ReadLine().ToLower();
          if (enter == "y" || enter == "yes" || enter == "yeah" || enter == "of course" || enter == "hell yeah" || enter == "hell yes" || enter == "no duh" || enter == "for sure" || enter == "sure" || enter == "i guess" || enter == "yeet")
          {
            return;
          }
          else
          {
            Console.Clear();
            System.Console.WriteLine("After seeing a dungeon for the first time, you got too scared to enter and went home to cry while taking a hot bath.");
            Questing = false;
          }
          break;
        case 'r':
          Console.Clear();
          System.Console.WriteLine("After lifting nearly 2,000 rocks, you lift your last rock of the day and hear a crack as the surrounding rocks\nfall down the mountainside. You notice a large boulder start moving your direction after displacing the smaller rocks\nholding it into place. You are unable to get out of the way in time and are crushed by the boulder.\nYou were never worthy of becoming a hero like Billy.");
          Questing = false;
          break;
        default:
          Console.Clear();
          System.Console.WriteLine("Please enter a valid strategy, either pull (B)ranches, or lift (R)ocks");
          SearchStrategy();
          break;
      }
    }

    public void GetUserInput()
    {
      string input = Console.ReadLine().ToLower();
      string[] inputs = input.Split(' ');
      string command = inputs[0];
      string option = "";
      if (inputs.Length > 1)
      {
        option = inputs[1];
      }
      switch (command)
      {
        case "go":
          Go(option);
          break;
        case "take":
          TakeItem(option);
          break;
        case "use":
          UseItem(option);
          break;
        case "inventory":
          Inventory();
          break;
        case "look":
          Look();
          break;
        case "help":
          Help();
          break;
        case "quit":
          break;
        case "reset":
          break;
        default:
          Console.Clear();
          System.Console.WriteLine("Please enter a valid command.");
          Thread.Sleep(1000);
          break;
      }
    }

    public void Go(string direction)
    {
      switch (direction)
      {
        case "north":
          CurrentRoom = (Room)CurrentRoom.TraveltoRoom(Direction.north);
          break;
        case "east":
          CurrentRoom = (Room)CurrentRoom.TraveltoRoom(Direction.east);
          break;
        case "south":
          CurrentRoom = (Room)CurrentRoom.TraveltoRoom(Direction.south);
          break;
        case "west":
          CurrentRoom = (Room)CurrentRoom.TraveltoRoom(Direction.west);
          break;
        default:
          Console.Clear();
          System.Console.WriteLine("Please enter a valid direction: 'North', 'East', 'South', or 'West'.");
          Thread.Sleep(2000);
          break;
      }
    }

    public void TakeItem(string itemName)
    {
      Item item = ValidateItem(itemName, CurrentRoom.Items);
      if (item != null)
      {
        Console.Clear();
        CurrentRoom.Items.Remove(item);
        CurrentPlayer.AddItem(item);
        System.Console.WriteLine($"You took the {itemName}");
        Thread.Sleep(1000);

      }
      else
      {
        Console.Clear();
        System.Console.WriteLine(CurrentRoom.Items.Count > 0 ? $"Couldn't find {itemName}" : "There is nothing to be taken.");
        Thread.Sleep(1000);
      }
    }

    private Item ValidateItem(string input, List<Item> itemList)
    {
      return itemList.Find(i =>
      {
        return i.Name.ToLower() == input;
      });
      //here is where you would want to change the description
    }

    public void UseItem(string itemName)
    {
      Console.Clear();
      // CurrentRoom.AddItem(item);
      // CurrentPlayer.Inventory.Remove(item);
      // System.Console.WriteLine($"You used the {itemName}");
      // Thread.Sleep(1500);
      switch (itemName)
      {
        case "key":
          Item item = ValidateItem(itemName, CurrentPlayer.Inventory);
          if (item == null)
          {
            Console.Clear();
            System.Console.WriteLine(CurrentRoom.Items.Count > 0 ? $"You don't have a {itemName}" : "You have nothing to use.");
            Thread.Sleep(1000);
            return;
          }
          if (CurrentRoom.LockedRooms.ContainsKey("key") && KeyNarritive(item))
          {
            CurrentRoom.Use("key");
          }
          else
          {
            System.Console.WriteLine("You see a small hole in the wall and decide to stick the key into it...");
            System.Console.WriteLine("It does nothing");
          }
          break;
        case "fountain":
          if (CurrentRoom.Name == "fountain")
          {
            System.Console.WriteLine("It's a random fountain in an old grimy dungeon. Are you sure you want to drink from it?");
            string enter = Console.ReadLine().ToLower();
            if (enter == "y" || enter == "yes" || enter == "yeah" || enter == "of course" || enter == "hell yeah" || enter == "hell yes" || enter == "no duh" || enter == "for sure" || enter == "sure" || enter == "i guess" || enter == "yeet")
            {
              System.Console.WriteLine("You take a drink from the fountaina nd instantly realize it was a maginal fountain. You're entire body feels indestructable, maybe you should try it out!");
              CurrentPlayer.Immune = true;
            }
            else
            {
              System.Console.WriteLine("You decide not to drink from the fountain.");
            }
          }
          break;

      }
    }

    private bool KeyNarritive(Item item)
    {
      System.Console.WriteLine("You take out the key and insert it into the giant door to the East. It seems like the key is a perfect fit, but it doesn't budge when you turn it.");
      System.Console.WriteLine("");
      System.Console.WriteLine("Do you want to force the key?");
      string force = Console.ReadLine().ToLower();
      if (force == "y" || force == "yes" || force == "yeah" || force == "of course" || force == "hell yeah" || force == "hell yes" || force == "no duh" || force == "for sure" || force == "sure" || force == "i guess" || force == "yeet")
      {
        CurrentPlayer.Inventory.Remove(item);
        System.Console.WriteLine("As you force the key, you hear a slight click just as the key snaps off while inside the door. You push on the door and are able to move it just enough to squeeze in." + Environment.NewLine);
        System.Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
        return true;
      }
      else
      {
        System.Console.WriteLine("You removed they key from the keyhole on the door.");
        Thread.Sleep(1500);
        return false;
      }
    }

    public void Inventory()
    {
      Console.Clear();
      System.Console.WriteLine($"{CurrentRoom.Description}");
      System.Console.WriteLine("");
      CurrentPlayer.PrintInventory();
      System.Console.WriteLine("");
      System.Console.WriteLine("What would you like to do?");
      GetUserInput();
    }


    public void Look()
    {
      Console.Clear();
      System.Console.WriteLine($"{CurrentRoom.Description}");
      System.Console.WriteLine("");
      CurrentRoom.PrintRoomItems();
      System.Console.WriteLine("");
      System.Console.WriteLine("What would you like to do?");
      GetUserInput();
    }
    public void Help()
    {
      Console.Clear();
      System.Console.WriteLine(@"Here are some acceptable commands for your quest:

 go + {North/East/South/West} = move in direction you specify
 take + {item} = take item you specify
 use + {item} = use item you specify
 inventory = shows items you are carrying
 look = shows description of the room
 quit = exits out of the game
 reset = restarts the game");
      System.Console.WriteLine("");
      System.Console.WriteLine("Press any key to continue.");
      Console.ReadKey();
    }

    public void Quit()
    {

    }

    public void Reset()
    {

    }



  }
}