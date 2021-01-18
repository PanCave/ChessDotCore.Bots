using ChessDotCore.Bots.Interfaces;
using ChessDotCore.Engine.Interfaces;
using System;
using System.Diagnostics;

namespace ChessDotCore.Bots
{
  public class ParallelMiniMaxBot : IChessBot
  {
    private readonly IEvaluator evaluator;
    private readonly IDecisionRule miniMax;
    private readonly IMoveSorter moveSorter;

    public ParallelMiniMaxBot(IGame game, Color botColor, int depth)
    {
      evaluator = new Evaluator(game, botColor);
      moveSorter = new MoveSorter(game, evaluator);
      miniMax = new ParallelMiniMax(game, botColor, evaluator, moveSorter, depth);
    }

    public IMove MakeMove()
    {
      evaluator.EvaluationCount = 0;
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      IMove move = miniMax.BestMove();
      stopwatch.Stop();
      Console.WriteLine($"{evaluator.EvaluationCount} Stellung in {stopwatch.Elapsed:mm\\:ss}s {stopwatch.ElapsedMilliseconds}ms evaluiert");
      return move;
    }
  }
}