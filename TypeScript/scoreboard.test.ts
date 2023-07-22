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
});
