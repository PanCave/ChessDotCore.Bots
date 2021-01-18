using ChessDotCore.Bots.Interfaces;
using ChessDotCore.Engine.Interfaces;
using System.Collections.Generic;

namespace ChessDotCore.Bots
{
  internal class Evaluator : IEvaluator
  {
    private readonly Color color;
    private readonly IGame game;
    private readonly MiniMaxBotData miniMaxBotData;
    private readonly Color opponentColor;

    public Evaluator(IGame game, Color color)
    {
      this.game = game;
      this.color = color;
      opponentColor = color == Color.White ? Color.Black : Color.White;
      miniMaxBotData = new MiniMaxBotData();
    }

    public double Evaluate()
    {
      EvaluationCount++;
      if (game.Board.IsCheckMate) return game.Board.Turn == color ? -1000000 : 1000000;
      double sum = 0;
      foreach (IPiece piece in game.Board.Pieces)
      {
        if (piece.Square == null) continue;
        double summand = 0;
        summand += miniMaxBotData[piece.PieceType];
        summand += miniMaxBotData[7 - piece.Square.Rank, piece.Square.File, piece.PieceType, piece.Color];

        if (piece.Color == color) sum += summand;
        else sum -= summand;
      }
      return sum;
    }

    public double EvaluateComplex(bool count = true)
    {
      if (count) EvaluationCount++;
      if (game.Board.IsCheckMate) return game.Board.Turn == color ? -1000000 : 1000000;
      double sum = 0;
      List<IPiece> pieces = game.Board[color, true];
      foreach (IPiece piece in pieces)
      {
        double summand = 0;
        summand += miniMaxBotData[piece.PieceType];
        summand += miniMaxBotData[piece.Square.Rank, piece.Square.File, piece.PieceType, piece.Color];
        foreach (ISquare square in piece.AttackedSquares)
        {
          summand += miniMaxBotData[square.Rank, square.File];
        }
        foreach (ISquare square in piece.ProtectedSquares)
        {
          summand += miniMaxBotData[square.Rank, square.File] * 2;
        }
        summand += piece.ReachableSquares.Count;
        summand += miniMaxBotData[piece.Square.Rank, piece.Square.File] * 3;

        sum += summand;
      }

      foreach (IPiece piece in game.Board[opponentColor, true])
      {
        double summand = 0;
        summand += miniMaxBotData[piece.PieceType];
        summand += miniMaxBotData[piece.Square.Rank, piece.Square.File, piece.PieceType, piece.Color];
        foreach (ISquare square in piece.AttackedSquares)
        {
          summand += miniMaxBotData[square.Rank, square.File];
        }
        foreach (ISquare square in piece.ProtectedSquares)
        {
          summand += miniMaxBotData[square.Rank, square.File] * 2;
        }
        summand += piece.ReachableSquares.Count;
        summand += miniMaxBotData[piece.Square.Rank, piece.Square.File] * 3;

        sum -= summand;
      }
      return sum;
    }

    public double EvaluateSimple()
    {
      if (game.Board.IsCheckMate) return game.Board.Turn == color ? -1000000 : 1000000;
      double sum = 0;
      foreach (IPiece piece in game.Board.Pieces)
      {
        if (piece.Square == null) continue;
        double summand = 0;
        summand += miniMaxBotData[piece.PieceType];
        summand += miniMaxBotData[7 - piece.Square.Rank, piece.Square.File, piece.PieceType, piece.Color];

        if (piece.Color == color) sum += summand;
        else sum -= summand;
      }
      return sum;
    }

    public int EvaluationCount { get; set; }
  }
}