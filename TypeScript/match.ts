export class Match {
    homeTeam: string;
    awayTeam: string;
    homeScore: number;
    awayScore: number;
    startTime: Date;

    constructor(homeTeam: string, awayTeam: string) {
        if (!homeTeam || homeTeam.trim() === '') {
            throw new Error('homeTeam cannot be empty or only whitespace');
        }

        if (!awayTeam || awayTeam.trim() === '') {
            throw new Error('awayTeam cannot be empty or only whitespace');
        }

        if (homeTeam === awayTeam) {
            throw new Error('homeTeam and awayTeam cannot be the same');
        }
        
        this.homeTeam = homeTeam;
        this.awayTeam = awayTeam;
        this.homeScore = 0;
        this.awayScore = 0;
        this.startTime = new Date();
    }

    updateScore(homeScore: number, awayScore: number): void {
        this.homeScore = homeScore;
        this.awayScore = awayScore;
    }

    totalScore(): number {
        return this.homeScore + this.awayScore;
    }
}