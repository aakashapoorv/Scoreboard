import { ScoreBoard } from './scoreboard';
import { Match } from './match';

describe('ScoreBoard', () => {
  let scoreBoard: ScoreBoard;

  beforeEach(() => {
    scoreBoard = new ScoreBoard();
  });

  test('start a new match', () => {
    const match = scoreBoard.startMatch('Team A', 'Team B');
    expect(match.homeTeam).toEqual('Team A');
    expect(match.awayTeam).toEqual('Team B');
    expect(match.homeScore).toEqual(0);
    expect(match.awayScore).toEqual(0);
  });

  test('update score', () => {
    const match = new Match('Team A', 'Team B');
    match.updateScore(3, 2);
    expect(match.homeScore).toEqual(3);
    expect(match.awayScore).toEqual(2);
  });

  test('finish match', () => {
    const match = scoreBoard.startMatch('Team A', 'Team B');
    scoreBoard.finishMatch(match);
    expect(scoreBoard.matches).not.toContain(match);
  });
});
