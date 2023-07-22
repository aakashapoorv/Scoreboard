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
    }
}
