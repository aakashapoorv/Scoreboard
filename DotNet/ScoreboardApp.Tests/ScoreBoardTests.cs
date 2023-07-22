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

        [Test]
        public void Summary_ReturnsSortedSummary()
        {
            var match1 = _scoreBoard.StartMatch("Team A", "Team B");
            var match2 = _scoreBoard.StartMatch("Team C", "Team D");
            match1.UpdateScore(3, 2);
            match2.UpdateScore(2, 2);

            var summary = _scoreBoard.Summary();

            Assert.AreEqual("Team A", summary.First().HomeTeam);
            Assert.AreEqual("Team B", summary.First().AwayTeam);
            Assert.AreEqual(3, summary.First().HomeScore);
            Assert.AreEqual(2, summary.First().AwayScore);

            Assert.AreEqual("Team C", summary.Last().HomeTeam);
            Assert.AreEqual("Team D", summary.Last().AwayTeam);
            Assert.AreEqual(2, summary.Last().HomeScore);
            Assert.AreEqual(2, summary.Last().AwayScore);
        }

        [Test]
        public void Constructor_ThrowsException_WhenHomeTeamAndAwayTeamAreTheSame()
        {
            Assert.Throws<ArgumentException>(() => new Match("Team A", "Team A"));
        }

        [Test]
        public void Constructor_ThrowsException_WhenHomeTeamIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Match(null, "Team B"));
        }

        [Test]
        public void Constructor_ThrowsException_WhenAwayTeamIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Match("Team A", null));
        }

        [Test]
        public void Constructor_ThrowsException_WhenHomeTeamIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Match("", "Team B"));
        }

        [Test]
        public void Constructor_ThrowsException_WhenAwayTeamIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Match("Team A", ""));
        }

        [Test]
        public void Constructor_ThrowsException_WhenHomeTeamIsWhitespace()
        {
            Assert.Throws<ArgumentException>(() => new Match("  ", "Team B"));
        }

        [Test]
        public void Constructor_ThrowsException_WhenAwayTeamIsWhitespace()
        {
            Assert.Throws<ArgumentException>(() => new Match("Team A", "  "));
        }

        [Test]
        public void UpdateScore_NegativeScore_ThrowsException()
        {
            var match = new Match("Team A", "Team B");
            Assert.Throws<ArgumentException>(() => match.UpdateScore(-1, 2));
            Assert.Throws<ArgumentException>(() => match.UpdateScore(2, -1));
        }

        [Test]
        public void UpdateScore_ScoreLowerThanPrevious_ThrowsException()
        {
            var match = new Match("Team A", "Team B");
            match.UpdateScore(3, 2);
            Assert.Throws<ArgumentException>(() => match.UpdateScore(2, 2));
            Assert.Throws<ArgumentException>(() => match.UpdateScore(3, 1));
        }

        [Test]
        public void UpdateScore_AfterMatchEnds_ThrowsException()
        {
            var match = new Match("Team A", "Team B");
            match.EndMatch();
            Assert.Throws<InvalidOperationException>(() => match.UpdateScore(2, 2));
        }

        [Test]
        public void UpdateScore_AfterMatchEnds_ThrowsException()
        {
            var match = new Match("Team A", "Team B");
            match.EndMatch();
            Assert.Throws<InvalidOperationException>(() => match.UpdateScore(2, 2));
        }
    }
}
