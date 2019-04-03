using System;
using System.Collections.Generic;
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
      System.Console.WriteLine("You are a peasant in the Land of Ooo, and are looking to become a legendary adventurer like your idol, Billy the Hero.\nYou decide to do whatever it may take in order to accomplish a feat worthy of qualifying you as a notable hero.\nSince beginning your quest, you have been lifting rocks and pulling on tree branches in hopes of\ndiscovering a secret dungeon in the process. Today you have decided to quest for dungeons in the Enchiridion Mountains;\na forbidden land crawling with death and disease.");
      System.Console.WriteLine("");
      System.Console.WriteLine("In order to make your search easier, you decide to either only pull on branches, or to only lift rocks.\nWhich do you choose, (B)ranches or (R)ocks?");
      SearchStrategy();
      while (Questing)
      {
        System.Console.WriteLine($"{CurrentRoom.Description}");
        System.Console.WriteLine("What would you like to do?");
        string choice = Console.ReadLine();
      }

    }



    public void Setup()
    {
      //Create all Rooms
      Room start = new Room("Entry", "You stand in a very dark room. You see a faint glow in the distance coming from the North, in what you can only assume is another section of the dungeon.");
      Room middle = new Room("Middle", "There is a very noticable fire burning in a doorway leading to another room to the West. You can barely make out a few items scattered around the room as the light flickers. As your eyes adjust, you see a closed door on the East side of the room.");
      Room right = new Room("Right", "The room is pitch black. You are unable to see anything.");
      Room left = new Room("Left", "With the absence of the fire barrier, you are unable to see what lies before you.");

      //Establish relationships
      start.AddExit(Direction.north, middle);
      middle.AddExit(Direction.east, right);
      middle.AddExit(Direction.south, start);
      middle.AddExit(Direction.west, left);
      right.AddExit(Direction.west, middle);
      left.AddExit(Direction.east, middle);

      CurrentRoom = start;
      Questing = true;

    }

    void SearchStrategy()
    {
      string strategy = Console.ReadLine();
      switch (strategy.ToLower()[0])
      {
        case 'b':
          System.Console.WriteLine("After pulling on nearly 2,000 branches, you pull on your last branch of the day and hear a click as it pulls down\ntoward the ground. You notice a nearby boulder moveing to slowly reveal an entry point of a dungeon. ");
          System.Console.WriteLine("Do you wish to enter the dungeon?");
          string enter = Console.ReadLine().ToLower();
          if (enter == "y" || enter == "yes" || enter == "yeah" || enter == "of course" || enter == "hell yeah" || enter == "hell yes" || enter == "no duh")
          {
            return;
          }
          else
          {
            System.Console.WriteLine("After seeing a dungeon for the first time, you got too scared to enter and went home to cry while taking a hot bath.");
            Questing = false;
          }
          break;
        case 'r':
          System.Console.WriteLine("After lifting nearly 2,000 rocks, you lift your last rock of the day and hear a crack as the surrounding rocks\nfall down the mountainside. You notice a large boulder start moving your direction after displacing the smaller rocks\nholding it into place. You are unable to get out of the way in time and are crushed by the boulder.\nYou were never worthy of becoming a hero like Billy.");
          Questing = false;
          break;
        default:
          System.Console.WriteLine("Please enter a valid strategy, either pull (B)ranches, or lift (R)ocks");
          SearchStrategy();
          break;
      }
    }












    public void GetUserInput()
    {

    }

    public void Go(Direction direction)
    {

    }

    public void Help()
    {

    }

    public void Inventory()
    {

    }

    public void Look()
    {

    }

    public void Quit()
    {

    }

    public void Reset()
    {

    }



    public void TakeItem(string itemName)
    {

    }

    public void UseItem(string itemName)
    {

    }
  }
}