using System;

namespace ScoreboardApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the Scoreboard
            var scoreBoard = new Scoreboard();

            // Start matches and update scores
            var match1 = scoreBoard.StartMatch("Mexico", "Canada");
            match1.UpdateScore(0, 5);

            var match2 = scoreBoard.StartMatch("Spain", "Brazil");
            match2.UpdateScore(10, 2);

            var match3 = scoreBoard.StartMatch("Germany", "France");
            match3.UpdateScore(2, 2);

            var match4 = scoreBoard.StartMatch("Uruguay", "Italy");
            match4.UpdateScore(6, 6);

            var match5 = scoreBoard.StartMatch("Argentina", "Australia");
            match5.UpdateScore(3, 1);

            // Output the match summaries
            var summaries = scoreBoard.Summary();

            foreach (var summary in summaries)
            {
                Console.WriteLine($"Home Team: {summary.HomeTeam}, Away Team: {summary.AwayTeam}, Home Score: {summary.HomeScore}, Away Score: {summary.AwayScore}");
            }
        }
    }
}
