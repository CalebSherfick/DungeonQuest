using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public class Program
  {
    public static void Main(string[] args)
    {
      GameService gs = new GameService();
      gs.StartGame();
    }
  }
}
