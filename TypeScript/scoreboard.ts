import { Match } from './match';
export class ScoreBoard {
    matches: Match[];

    constructor() {
        this.matches = [];
    }

    startMatch(homeTeam: string, awayTeam: string): Match {
        const match = new Match(homeTeam, awayTeam);
        this.matches.push(match);
        return match;
    }

    finishMatch(match: Match): void {
        match.endMatch();
        const index = this.matches.indexOf(match);
        if (index > -1) {
            this.matches.splice(index, 1);
        }
    }

    summary(): { homeTeam: string, awayTeam: string, homeScore: number, awayScore: number }[] {
        // Sorting matches by total score and start time
        const sortedMatches = this.matches.sort((a, b) => b.totalScore() - a.totalScore() || b.startTime.getTime() - a.startTime.getTime());
        return sortedMatches.map(match => ({
            homeTeam: match.homeTeam,
            awayTeam: match.awayTeam,
            homeScore: match.homeScore,
            awayScore: match.awayScore
        }));
    }
}
