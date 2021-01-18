using ChessDotCore.Bots.Interfaces;
using ChessDotCore.Engine;
using ChessDotCore.Engine.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace ChessDotCore.Bots.Tests
{
  [TestFixture]
  public class EvaluatorTests
  {
    private IChess chess;

    [Test]
    public void EvaluateSimpleTest()
    {
      IGame game = chess.CreateGame("Game");
      IEvaluator evaluator = new Evaluator(game, Color.White);

      double eval = evaluator.EvaluateSimple();

      eval.Should().Be(0);
    }

    [Test]
    public void EvaluateTest()
    {
      IGame game = chess.CreateGame("Game");
      IEvaluator evaluator = new Evaluator(game, Color.White);

      double eval = evaluator.Evaluate();

      eval.Should().Be(0);
    }

    [SetUp]
    public void Setup()
    {
      chess = new Chess();
    }
  }
}