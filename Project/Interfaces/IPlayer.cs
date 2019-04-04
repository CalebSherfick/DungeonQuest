using System.Collections.Generic;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project.Interfaces
{
  public interface IPlayer
  {
    string Name { get; set; }
    List<Item> Inventory { get; set; }
  }
}
