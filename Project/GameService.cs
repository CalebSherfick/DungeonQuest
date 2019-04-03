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


    public void StartGame()
    {
      Setup();
      while (Questing)
      {
        System.Console.WriteLine($"{CurrentRoom.Description}");
        System.Console.WriteLine("What would you like to do?");
        string choice = Console.ReadLine();
      }

    }












    public void GetUserInput()
    {

    }

    public void Go(string direction)
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