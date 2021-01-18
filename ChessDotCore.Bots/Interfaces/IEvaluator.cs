namespace ChessDotCore.Bots.Interfaces
{
  internal interface IEvaluator
  {
    double Evaluate();

    double EvaluateComplex(bool count = true);

    double EvaluateSimple();

    int EvaluationCount { get; set; }
  }
}