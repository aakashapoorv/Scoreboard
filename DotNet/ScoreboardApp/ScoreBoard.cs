using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreboardApp
{
    public class Scoreboard
    {
        public List<Match> Matches { get; set; }

        public Scoreboard()
        {
            Matches = new List<Match>();
        }

        public Match StartMatch(string homeTeam, string awayTeam)
        {
            var match = new Match(homeTeam, awayTeam);
            Matches.Add(match);
            return match;
        }

        public void FinishMatch(Match match)
        {
            Matches.Remove(match);
        }

        public List<Match> Summary()
        {
            return Matches
                .OrderByDescending(match => match.TotalScore())
                .ThenByDescending(match => match.StartTime)
                .ToList();
        }
    }
}
