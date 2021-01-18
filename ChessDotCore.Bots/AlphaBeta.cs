namespace ChessDotCore.Bots
{
  internal class AlphaBeta
  {
    public AlphaBeta(double alpha, double beta)
    {
      Alpha = alpha;
      Beta = beta;
    }

    public double Alpha { get; set; }
    public double Beta { get; set; }
  }
}