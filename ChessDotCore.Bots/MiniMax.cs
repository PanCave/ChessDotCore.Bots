using ChessDotCore.Bots.Interfaces;
using ChessDotCore.Engine.Interfaces;
using System;
using System.Collections.Generic;

namespace ChessDotCore.Bots
{
  internal class MiniMax : IDecisionRule
  {
    private readonly Color color;
    private readonly IEvaluator evaluator;
    private readonly IGame game;
    private readonly IMoveSorter moveSorter;
    private Dictionary<string, double> boardMap;

    public MiniMax(IGame game, Color color, IEvaluator evaluator, IMoveSorter moveSorter, int depth)
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

    private double InnerMiniMax(int depth, double alpha, double beta)
    {
      if (depth < 1 || game.Board.IsCheckMate) return evaluator.EvaluateComplex();
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
          double currentEvaluation = InnerMiniMax(depth - 1, alpha, beta);
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
        //(moveSorter as MoveSorterByPieceType).GameState = GameState.EarlyGame;
        (moveSorter as MoveSorter).Ascending = true;
        IMove[] sortedMoves = moveSorter.SortedMoves();
        foreach (IMove move in sortedMoves)
        //foreach (IMove move in game.Board.LegalMoves)
        {
          game.Move(move);
          string boardHash = $"{game.Board.Fen}_{depth}";
          if (boardMap.ContainsKey(boardHash))
          {
            game.UndoMove();
            return boardMap[boardHash];
          }
          double currentEvaluation = InnerMiniMax(depth - 1, alpha, beta);
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
      //(moveSorter as MoveSorterByPieceType).GameState = GameState.EarlyGame;
      (moveSorter as MoveSorter).Ascending = false;
      IMove[] sortedMoves = moveSorter.SortedMoves();
      IMove bestMove = null;
      double bestEvaluation = double.NegativeInfinity;
      foreach (IMove move in sortedMoves)
      //foreach (IMove move in game.Board.LegalMoves)
      {
        int t = game.Board.TurnNumber;
        game.Move(move);
        double currentEvaluation = InnerMiniMax(depth - 1, alpha, beta);
        if (currentEvaluation > bestEvaluation)
        {
          bestEvaluation = currentEvaluation;
          bestMove = move;
        }
        game.UndoMove();
        alpha = Math.Max(currentEvaluation, alpha);
        if (alpha > beta) break;
        if (t != game.Board.TurnNumber) throw new Exception("TurnNumber does not match!");
      }
      return bestMove;
    }

    public int Depth { get; set; }
  }
}