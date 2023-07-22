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

        public Match(string homeTeam, string awayTeam)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeScore = 0;
            AwayScore = 0;
            StartTime = DateTime.Now;
        }

        public void UpdateScore(int homeScore, int awayScore)
        {
            HomeScore = homeScore;
            AwayScore = awayScore;
        }

        public int TotalScore()
        {
            return HomeScore + AwayScore;
        }
    }
}
