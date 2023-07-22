using System;

namespace ScoreboardApp
{
    public class Match
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime StartTime { get; set; }
        public bool MatchEnded { get; private set; }

        public Match(string homeTeam, string awayTeam)
        {
            if (string.IsNullOrWhiteSpace(homeTeam) || string.IsNullOrWhiteSpace(awayTeam))
            {
                throw new ArgumentException("Team names cannot be null or empty.");
            }

            if (homeTeam == awayTeam)
            {
                throw new ArgumentException("The home team and the away team cannot be the same.");
            }

            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeScore = 0;
            AwayScore = 0;
            StartTime = DateTime.Now;
            MatchEnded = false;
        }

        public void EndMatch()
        {
            MatchEnded = true;
        }

        public void UpdateScore(int homeScore, int awayScore)
        {
            if (homeScore < 0 || awayScore < 0)
            {
                throw new ArgumentException("Scores cannot be negative.");
            }

            if (homeScore < HomeScore || awayScore < AwayScore)
            {
                throw new ArgumentException("New score must not be lower than the previous score.");
            }

            if (MatchEnded)
            {
                throw new InvalidOperationException("Cannot update score after the match has ended.");
            }
            HomeScore = homeScore;
            AwayScore = awayScore;
        }

        public int TotalScore()
        {
            return HomeScore + AwayScore;
        }
    }
}
