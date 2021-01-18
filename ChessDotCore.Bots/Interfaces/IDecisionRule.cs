using ChessDotCore.Engine.Interfaces;

namespace ChessDotCore.Bots.Interfaces
{
  internal interface IDecisionRule
  {
    IMove BestMove();
  }
}