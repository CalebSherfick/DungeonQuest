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


    public void PrintRoomItems()
    {
      Console.WriteLine("Interactable items in the room: ");
      Items.ForEach(item =>
      {
        Console.WriteLine(item.Name);
      });
    }

    public void AddExit(Direction direction, IRoom room)
    {
      Exits.Add(direction, room);
    }

    public IRoom TraveltoRoom(Direction dir)
    {
      if (Exits.ContainsKey(dir))
      {
        return Exits[dir];
      }
      Console.Clear();
      System.Console.WriteLine("There is nowhere to go in that direction.");
      Thread.Sleep(1500);
      return (IRoom)this;
    }

    public Room(string name, string desc)
    {
      Exits = new Dictionary<Direction, IRoom>();
      Items = new List<Item>();
      Name = name;
      Description = desc;
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