using ChessDotCore.Engine.Interfaces;

namespace ChessDotCore.Bots
{
  internal class MiniMaxBotData
  {
    public MiniMaxBotData()
    {
      PawnEvalWhite = new double[,]
      {
        { 0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0},
        { 5.0,  5.0,  5.0,  5.0,  5.0,  5.0,  5.0,  5.0},
        { 1.0,  1.0,  2.0,  3.0,  3.0,  2.0,  1.0,  1.0},
        { 0.5,  0.5,  1.0,  2.5,  2.5,  1.0,  0.5,  0.5},
        { 0.0,  0.0,  0.0,  2.0,  2.0,  0.0,  0.0,  0.0},
        { 0.5, -0.5, -1.0,  0.0,  0.0, -1.0, -0.5,  0.5},
        { 0.5,  1.0,  1.0, -2.0, -2.0,  1.0,  1.0,  0.5},
        { 0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0}
      };
      PawnEvalBlack = new double[,]
      {
        { 0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0},
        { 0.5,  1.0,  1.0, -2.0, -2.0,  1.0,  1.0,  0.5},
        { 0.5, -0.5, -1.0,  0.0,  0.0, -1.0, -0.5,  0.5},
        { 0.0,  0.0,  0.0,  2.0,  2.0,  0.0,  0.0,  0.0},
        { 0.5,  0.5,  1.0,  2.5,  2.5,  1.0,  0.5,  0.5},
        { 1.0,  1.0,  2.0,  3.0,  3.0,  2.0,  1.0,  1.0},
        { 5.0,  5.0,  5.0,  5.0,  5.0,  5.0,  5.0,  5.0},
        { 0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0}
      };
      KnightEval = new double[,]
      {
        {-5.0, -4.0, -3.0, -3.0, -3.0, -3.0, -4.0, -5.0},
        {-4.0, -2.0,  0.0,  0.0,  0.0,  0.0, -2.0, -4.0},
        {-3.0,  0.0,  1.0,  1.5,  1.5,  1.0,  0.0, -3.0},
        {-3.0,  0.5,  1.5,  2.0,  2.0,  1.5,  0.5, -3.0},
        {-3.0,  0.0,  1.5,  2.0,  2.0,  1.5,  0.0, -3.0},
        {-3.0,  0.5,  1.0,  1.5,  1.5,  1.0,  0.5, -3.0},
        {-4.0, -2.0,  0.0,  0.5,  0.5,  0.0, -2.0, -4.0},
        {-5.0, -4.0, -3.0, -3.0, -3.0, -3.0, -4.0, -5.0}
      };
      BishopEvalWhite = new double[,]
      {
        {-2.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -2.0},
        {-1.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -1.0},
        {-1.0,  0.0,  0.5,  1.0,  1.0,  0.5,  0.0, -1.0},
        {-1.0,  0.5,  0.5,  1.0,  1.0,  0.5,  0.5, -1.0},
        {-1.0,  0.0,  1.0,  1.0,  1.0,  1.0,  0.0, -1.0},
        {-1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0, -1.0},
        {-1.0,  0.5,  0.0,  0.0,  0.0,  0.0,  0.5, -1.0},
        {-2.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -2.0}
      };
      BishopEvalBlack = new double[,]
      {
        {-2.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -2.0},
        {-1.0,  0.5,  0.0,  0.0,  0.0,  0.0,  0.5, -1.0},
        {-1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0, -1.0},
        {-1.0,  0.0,  1.0,  1.0,  1.0,  1.0,  0.0, -1.0},
        {-1.0,  0.5,  0.5,  1.0,  1.0,  0.5,  0.5, -1.0},
        {-1.0,  0.0,  0.5,  1.0,  1.0,  0.5,  0.0, -1.0},
        {-1.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -1.0},
        {-2.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -2.0}
      };
      RookEvalWhite = new double[,]
      {
        { 0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0},
        { 0.5,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  0.5},
        {-0.5,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -0.5},
        {-0.5,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -0.5},
        {-0.5,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -0.5},
        {-0.5,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -0.5},
        {-0.5,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -0.5},
        { 0.0,   0.0, 0.0,  0.5,  0.5,  0.0,  0.0,  0.0}
      };
      RookEvalBlack = new double[,]
      {
        { 0.0,  0.0,  0.0,  0.5,  0.5,  0.0,  0.0,  0.0},
        {-0.5,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -0.5},
        {-0.5,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -0.5},
        {-0.5,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -0.5},
        {-0.5,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -0.5},
        {-0.5,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -0.5},
        { 0.5,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  0.5},
        { 0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0}
      };
      QueenEval = new double[,]
      {
        {-2.0, -1.0, -1.0, -0.5, -0.5, -1.0, -1.0, -2.0},
        {-1.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -1.0},
        {-1.0,  0.0,  0.5,  0.5,  0.5,  0.5,  0.0, -1.0},
        {-0.5,  0.0,  0.5,  0.5,  0.5,  0.5,  0.0, -0.5},
        { 0.0,  0.0,  0.5,  0.5,  0.5,  0.5,  0.0, -0.5},
        {-1.0,  0.5,  0.5,  0.5,  0.5,  0.5,  0.0, -1.0},
        {-1.0,  0.0,  0.5,  0.0,  0.0,  0.0,  0.0, -1.0},
        {-2.0, -1.0, -1.0, -0.5, -0.5, -1.0, -1.0, -2.0}
      };
      KingEvalWhite = new double[,]
      {
        {-3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0},
        {-3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0},
        {-3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0},
        {-3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0},
        {-2.0, -3.0, -3.0, -4.0, -4.0, -3.0, -3.0, -2.0},
        {-1.0, -2.0, -2.0, -2.0, -2.0, -2.0, -2.0, -1.0},
        { 2.0,  2.0,  0.0,  0.0,  0.0,  0.0,  2.0,  2.0},
        { 2.0,  3.0,  1.0,  0.0,  0.0,  1.0,  3.0,  2.0}
      };
      KingEvalBlack = new double[,]
      {
        { 2.0,  3.0,  1.0,  0.0,  0.0,  1.0,  3.0,  2.0},
        { 2.0,  2.0,  0.0,  0.0,  0.0,  0.0,  2.0,  2.0},
        {-1.0, -2.0, -2.0, -2.0, -2.0, -2.0, -2.0, -1.0},
        {-2.0, -3.0, -3.0, -4.0, -4.0, -3.0, -3.0, -2.0},
        {-3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0},
        {-3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0},
        {-3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0},
        {-3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0}
      };
      CenterImportance = new double[,]{
        {0.0625, 0.0625, 0.0625, 0.0625, 0.0625, 0.0625, 0.0625, 0.0625},
        {0.0625, 0.0625, 0.0625, 0.0625, 0.0625, 0.0625, 0.0625, 0.0625},
        {0.0625, 0.0625,   0.25,    0.5,    0.5,   0.25, 0.0625, 0.0625},
        {0.0625, 0.0625,    0.5,      1,      1,    0.5, 0.0625, 0.0625},
        {0.0625, 0.0625,    0.5,      1,      1,    0.5, 0.0625, 0.0625},
        {0.0625, 0.0625,   0.25,    0.5,    0.5,   0.25, 0.0625, 0.0625},
        {0.0625, 0.0625, 0.0625, 0.0625, 0.0625, 0.0625, 0.0625, 0.0625},
        {0.0625, 0.0625, 0.0625, 0.0625, 0.0625, 0.0625, 0.0625, 0.0625}};
    }

    public double[,] BishopEvalBlack { get; }
    public double[,] BishopEvalWhite { get; }
    public double BishopPieceValue => 330;
    public double[,] CenterImportance { get; }
    public double[,] KingEvalBlack { get; }

    public double[,] KingEvalWhite { get; }

    public double KingPieceValue => 2000;
    public double[,] KnightEval { get; }

    public double KnightPieceValue => 320;
    public double[,] PawnEvalBlack { get; }

    public double[,] PawnEvalWhite { get; }

    public double PawnPieceValue => 100;
    public double[,] QueenEval { get; }

    public double QueenPieceValue => 900;
    public double[,] RookEvalBlack { get; }

    public double[,] RookEvalWhite { get; }
    public double RookPieceValue => 500;

    public double this[PieceType pieceType]
    {
      get
      {
        switch (pieceType)
        {
          case PieceType.Pawn: return PawnPieceValue;
          case PieceType.Bishop: return BishopPieceValue;
          case PieceType.Knight: return KnightPieceValue;
          case PieceType.Rook: return RookPieceValue;
          case PieceType.Queen: return QueenPieceValue;
          default:
          case PieceType.King: return KingPieceValue;
        }
      }
    }

    public double this[int rank, int file]
    {
      get
      {
        return CenterImportance[rank, file];
      }
    }

    public double this[int rank, int file, PieceType pieceType, Color color]
    {
      get
      {
        switch (pieceType)
        {
          case PieceType.Pawn:
            if (color == Color.White) return PawnEvalWhite[rank, file];
            else return PawnEvalBlack[rank, file];
          case PieceType.Bishop:
            if (color == Color.White) return BishopEvalWhite[rank, file];
            else return BishopEvalBlack[rank, file];
          case PieceType.Knight:
            return KnightEval[rank, file];

          case PieceType.Rook:
            if (color == Color.White) return RookEvalWhite[rank, file];
            else return RookEvalBlack[rank, file];
          case PieceType.Queen:
            return QueenEval[rank, file];

          default:
          case PieceType.King:
            if (color == Color.White) return KingEvalWhite[rank, file];
            else return KingEvalBlack[rank, file];
        }
      }
    }
  }
}