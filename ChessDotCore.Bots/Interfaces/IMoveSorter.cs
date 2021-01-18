using ChessDotCore.Engine.Interfaces;

namespace ChessDotCore.Bots.Interfaces
{
  internal interface IMoveSorter
  {
    IMove[] SortedMoves();
  }
}