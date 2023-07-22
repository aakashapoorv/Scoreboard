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
}
