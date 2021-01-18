using FluentAssertions;
using NUnit.Framework;

namespace ChessDotCore.Bots.Tests
{
  [TestFixture]
  public class MiniMaxBotDataTests
  {
    [Test]
    public void PSTMirrorTest()
    {
      MiniMaxBotData miniMaxBotData = new MiniMaxBotData();
      for (int i = 0; i < 8; i++)
      {
        for (int j = 0; j < 8; j++)
        {
          miniMaxBotData.PawnEvalWhite[i, j].Should().Be(miniMaxBotData.PawnEvalBlack[7 - i, j]);
          miniMaxBotData.BishopEvalWhite[i, j].Should().Be(miniMaxBotData.BishopEvalBlack[7 - i, j]);
          miniMaxBotData.RookEvalWhite[i, j].Should().Be(miniMaxBotData.RookEvalBlack[7 - i, j]);
          miniMaxBotData.KingEvalWhite[i, j].Should().Be(miniMaxBotData.KingEvalBlack[7 - i, j]);
        }
      }
    }
  }
}