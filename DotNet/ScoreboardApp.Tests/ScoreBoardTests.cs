using NUnit.Framework;
using ScoreboardApp;
using System.Linq;

namespace ScoreboardApp.Tests
{
    public class ScoreboardTests
    {
        private Scoreboard _scoreBoard;

        [SetUp]
        public void Setup()
        {
            _scoreBoard = new Scoreboard();
        }

        [Test]
        public void StartMatch_NewMatch_ReturnsCorrectMatch()
        {
            var match = _scoreBoard.StartMatch("Team A", "Team B");
            Assert.AreEqual("Team A", match.HomeTeam);
            Assert.AreEqual("Team B", match.AwayTeam);
            Assert.AreEqual(0, match.HomeScore);
            Assert.AreEqual(0, match.AwayScore);
        }
    }
}
