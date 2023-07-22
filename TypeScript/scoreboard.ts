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
        const index = this.matches.indexOf(match);
        if (index > -1) {
            this.matches.splice(index, 1);
        }
    }
}
