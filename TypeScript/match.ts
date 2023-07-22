export class Match {
    homeTeam: string;
    awayTeam: string;
    homeScore: number;
    awayScore: number;
    startTime: Date;
    matchEnded: boolean;

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
        this.matchEnded = false;
    }

    endMatch(): void {
        this.matchEnded = true;
    }

    updateScore(homeScore: number, awayScore: number): void {
        if (homeScore < 0 || awayScore < 0) {
            throw new Error("Scores cannot be negative.");
        }

        if (homeScore < this.homeScore || awayScore < this.awayScore) {
            throw new Error("New score must not be lower than the previous score.");
        }

        if (this.matchEnded) {
            throw new Error("Cannot update score after the match has ended.");
        }

        this.homeScore = homeScore;
        this.awayScore = awayScore;
    }

    totalScore(): number {
        return this.homeScore + this.awayScore;
    }
}