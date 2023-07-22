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

        [Test]
        public void UpdateScore_UpdateScore_ReturnsUpdatedScore()
        {
            var match = new Match("Team A", "Team B");
            match.UpdateScore(3, 2);
            Assert.AreEqual(3, match.HomeScore);
            Assert.AreEqual(2, match.AwayScore);
        }

        [Test]
        public void FinishMatch_FinishMatch_RemovesMatchFromScoreboard()
        {
            var match = _scoreBoard.StartMatch("Team A", "Team B");
            _scoreBoard.FinishMatch(match);
            Assert.IsFalse(_scoreBoard.Matches.Contains(match));
        }
    }
}
