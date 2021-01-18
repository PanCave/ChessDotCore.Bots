using ChessDotCore.Bots.Interfaces;
using ChessDotCore.Engine.Interfaces;
using System.Collections.Generic;

namespace ChessDotCore.Bots
{
  internal class MoveSorterByPieceType : IMoveSorter
  {
    private readonly IGame game;

    public MoveSorterByPieceType(IGame game)
    {
      this.game = game;
    }

    public GameState GameState { get; internal set; }

    public IMove[] SortedMoves()
    {
      List<IMove> pawnMoves = new List<IMove>();
      List<IMove> bishopKnightMoves = new List<IMove>();
      List<IMove> rookMoves = new List<IMove>();
      List<IMove> queenMoves = new List<IMove>();
      List<IMove> kingMoves = new List<IMove>();
      List<IMove> moves = new List<IMove>();

      foreach (IMove move in game.Board.LegalMoves)
      {
        switch (move.MovingPiece.PieceType)
        {
          case PieceType.Pawn: pawnMoves.Add(move); break;
          case PieceType.Bishop:
          case PieceType.Knight: bishopKnightMoves.Add(move); break;
          case PieceType.Rook: rookMoves.Add(move); break;
          case PieceType.Queen: queenMoves.Add(move); break;
          case PieceType.King: kingMoves.Add(move); break;
        }
      }

      if (GameState == GameState.Opening)
      {
        moves.AddRange(pawnMoves);
        moves.AddRange(bishopKnightMoves);
        moves.AddRange(rookMoves);
        moves.AddRange(queenMoves);
        moves.AddRange(kingMoves);
      }
      else if (GameState == GameState.MiddleGame)
      {
        moves.AddRange(bishopKnightMoves);
        moves.AddRange(pawnMoves);
        moves.AddRange(rookMoves);
        moves.AddRange(queenMoves);
        moves.AddRange(kingMoves);
      }
      else
      {
        moves.AddRange(queenMoves);
        moves.AddRange(kingMoves);
        moves.AddRange(rookMoves);
        moves.AddRange(bishopKnightMoves);
        moves.AddRange(pawnMoves);
      }
      return moves.ToArray();
    }
  }
}