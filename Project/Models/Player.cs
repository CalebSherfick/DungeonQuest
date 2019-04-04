using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player : IPlayer
  {
    public List<Item> Inventory { get; set; }
    public string Name { get; set; }

    public void AddItem(Item item)
    {
      Inventory.Add(item);
    }

    public Player(string name)
    {
      Name = name;
      Inventory = new List<Item>();
    }

    public void PrintInventory()
    {
      if (Inventory.Count > 0)
      {
        Console.WriteLine("You have gathered the following items from the dungeon:");
        Inventory.ForEach(item =>
        {
          Console.WriteLine(item.Name);
        });
      }
      else
      {
        System.Console.WriteLine("You have nothing, but the clothes on your back.");
      }
    }

  }
}