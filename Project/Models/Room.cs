using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<Direction, IRoom> Exits { get; set; }

    public Dictionary<string, KeyValuePair<Direction, IRoom>> LockedRooms { get; set; }


    public void PrintRoomItems()
    {
      if (Items.Count > 0)
      {
        Console.WriteLine("You notice the following laying around the room:");
        Items.ForEach(item =>
        {
          Console.WriteLine(item.Name);
        });
      }
      else
      {
        System.Console.WriteLine("There is nothing else to notice in this room.");
      }
    }

    public void AddExit(Direction direction, IRoom room)
    {
      Exits.Add(direction, room);
    }

    public void AddItem(Item item)
    {
      Items.Add(item);
    }

    public IRoom TraveltoRoom(Direction dir)
    {
      if (Exits.ContainsKey(dir))
      {
        return Exits[dir];
      }
      Console.Clear();
      System.Console.WriteLine("You are currently unable to go in that direction.");
      Thread.Sleep(1500);
      return (IRoom)this;
    }


    public bool Use(string itemName)
    {
      if (LockedRooms.ContainsKey(itemName))
      {
        KeyValuePair<Direction, IRoom> roomToAdd = LockedRooms[itemName];
        Exits.Add(roomToAdd.Key, roomToAdd.Value);
        LockedRooms.Remove(itemName);
        //Prompt that the room is now unlocked and there is an exit to the  _______
        return true;
      }
      return false;
    }

    public Room(string name, string desc)
    {
      Exits = new Dictionary<Direction, IRoom>();
      LockedRooms = new Dictionary<string, KeyValuePair<Direction, IRoom>>();
      Items = new List<Item>();
      Name = name;
      Description = desc;
    }

    internal void addLockedRoom(string unlockName, Direction dir, Room room)
    {
      KeyValuePair<Direction, IRoom> lockedRoom = new KeyValuePair<Direction, IRoom>(dir, room);
      LockedRooms.Add(unlockName, lockedRoom);
    }
  }

  public enum Direction
  {
    north,
    east,
    south,
    west
  }





}