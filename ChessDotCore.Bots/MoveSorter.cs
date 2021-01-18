using ChessDotCore.Bots.Interfaces;
using ChessDotCore.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessDotCore.Bots
{
  internal class MoveSorter : IMoveSorter
  {
    private readonly IEvaluator evaluator;
    private readonly IGame game;

    public MoveSorter(IGame game, IEvaluator evaluator)
    {
      this.game = game;
      this.evaluator = evaluator;
    }

    public IMove[] SortedMoves()
    {
      SortedDictionary<double, IMove> sortedMoves = Ascending ? new SortedDictionary<double, IMove>() : new SortedDictionary<double, IMove>(new DescendingComparer<double>());
      foreach (IMove move in game.Board.LegalMoves)
      {
        game.Move(move, true);
        double currentEvaluation = evaluator.EvaluateComplex(false);
        game.UndoMove();
        sortedMoves[currentEvaluation] = move;
      }
      return sortedMoves.Values.ToArray();
    }

    public IMove[] SortedMovesArr(bool ascending)
    {
      int movesCount = game.Board.LegalMoves.Count;
      IMove[] movesArray = new IMove[movesCount];
      double[] movesEvaluationArray = new double[movesCount];
      int i = 0;
      foreach (IMove move in game.Board.LegalMoves)
      {
        movesArray[i] = move;
        game.Move(move, true);
        movesEvaluationArray[i] = evaluator.EvaluateComplex(false);
        game.UndoMove();
        i++;
      }
      Quick_Sort(movesEvaluationArray, movesArray, 0, movesCount - 1);
      //return ascending ? movesArray : movesArray.Reverse().ToArray();
      if (!ascending) Array.Reverse(movesArray);
      return movesArray;
    }

    private int Partition(double[] evaluations, IMove[] moves, int left, int right)
    {
      double pivot = evaluations[left];
      while (true)
      {
        while (evaluations[left] < pivot)
        {
          left++;
        }

        while (evaluations[right] > pivot)
        {
          right--;
        }

        if (left < right)
        {
          double temp = evaluations[left];
          evaluations[left] = evaluations[right];
          evaluations[right] = temp;
          IMove tempMove = moves[left];
          moves[left] = moves[right];
          moves[right] = tempMove;

          if (evaluations[left] == evaluations[right]) left++;
        }
        else
        {
          return right;
        }
      }
    }

    private void Quick_Sort(double[] arr, IMove[] moves, int left, int right)
    {
      if (left < right)
      {
        int pivot = Partition(arr, moves, left, right);

        if (pivot > 1)
        {
          Quick_Sort(arr, moves, left, pivot - 1);
        }
        if (pivot + 1 < right)
        {
          Quick_Sort(arr, moves, pivot + 1, right);
        }
      }
    }

    public bool Ascending { get; internal set; }

    private class DescendingComparer<T> : IComparer<T> where T : IComparable<T>
    {
      public int Compare(T x, T y)
      {
        return y.CompareTo(x);
      }
    }
  }
}