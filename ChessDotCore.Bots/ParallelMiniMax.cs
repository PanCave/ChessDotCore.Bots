using ChessDotCore.Bots.Interfaces;
using ChessDotCore.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChessDotCore.Bots
{
  internal class ParallelMiniMax : IDecisionRule
  {
    private readonly Color color;
    private readonly IEvaluator evaluator;
    private readonly IGame game;
    private readonly IMoveSorter moveSorter;
    private Dictionary<string, double> boardMap;
    private Dictionary<IMove, double> results;

    public ParallelMiniMax(IGame game, Color color, IEvaluator evaluator, IMoveSorter moveSorter, int depth)
    {
      this.game = game;
      this.color = color;
      this.evaluator = evaluator;
      this.moveSorter = moveSorter;
      Depth = depth;
    }

    public IMove BestMove()
    {
      return OuterMiniMax(Depth, double.NegativeInfinity, double.PositiveInfinity);
    }

    private double InnerMiniMax(IGame game, int depth, double alpha, double beta)
    {
      if (depth < 1 || game.Board.IsCheckMate) return evaluator.Evaluate();
      if (game.Board.Turn == color)
      {
        double maxEvaluation = double.NegativeInfinity;
        (moveSorter as MoveSorter).Ascending = false;
        IMove[] sortedMoves = moveSorter.SortedMoves();
        foreach (IMove move in sortedMoves)
        {
          game.Move(move);
          string boardHash = $"{game.Board.Fen}_{depth}";
          if (boardMap.ContainsKey(boardHash))
          {
            game.UndoMove();
            return boardMap[boardHash];
          }
          double currentEvaluation = InnerMiniMax(game, depth - 1, alpha, beta);
          boardMap[boardHash] = currentEvaluation;
          game.UndoMove();
          maxEvaluation = Math.Max(maxEvaluation, currentEvaluation);
          alpha = Math.Max(alpha, currentEvaluation);
          if (alpha > beta) break;
        }
        return maxEvaluation;
      }
      else
      {
        double minEvaluation = double.PositiveInfinity;
        (moveSorter as MoveSorter).Ascending = true;
        IMove[] sortedMoves = moveSorter.SortedMoves();
        foreach (IMove move in sortedMoves)
        {
          game.Move(move);
          string boardHash = $"{game.Board.Fen}_{depth}";
          if (boardMap.ContainsKey(boardHash))
          {
            game.UndoMove();
            return boardMap[boardHash];
          }
          double currentEvaluation = InnerMiniMax(game, depth - 1, alpha, beta);
          boardMap[boardHash] = currentEvaluation;
          game.UndoMove();
          minEvaluation = Math.Min(minEvaluation, currentEvaluation);
          beta = Math.Min(beta, currentEvaluation);
          if (beta < alpha) break;
        }
        return minEvaluation;
      }
    }

    private IMove OuterMiniMax(int depth, double alpha, double beta)
    {
      boardMap = new Dictionary<string, double>();
      results = new Dictionary<IMove, double>();
      (moveSorter as MoveSorter).Ascending = game.Board.Turn != color;
      IMove[] sortedMoves = moveSorter.SortedMoves();
      IMove bestMove = null;
      double bestEvaluation = double.NegativeInfinity;
      List<Task<double>> tasks = new List<Task<double>>();
      foreach (IMove move in sortedMoves)
      {
        Task<double> t = new Task<double>(() =>
        {
          IGame g = game.Clone();
          g.Move(move);
          double currentEvaluation = InnerMiniMax(g, depth - 1, alpha, beta);
          results[move] = currentEvaluation;
          alpha = Math.Max(currentEvaluation, alpha);
          return currentEvaluation;
        });
        t.Start();
        tasks.Add(t);
      }
      Task.WaitAll(tasks.ToArray());

      foreach (KeyValuePair<IMove, double> keyValuePair in results)
      {
        if (keyValuePair.Value > bestEvaluation)
        {
          bestEvaluation = keyValuePair.Value;
          bestMove = keyValuePair.Key;
        }
      }

      return bestMove;
    }

    public int Depth { get; set; }
  }
}