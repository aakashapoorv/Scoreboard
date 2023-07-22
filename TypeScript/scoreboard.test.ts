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

  test('get a summary of matches', () => {
    const match1 = scoreBoard.startMatch('Team A', 'Team B');
    const match2 = scoreBoard.startMatch('Team C', 'Team D');
    match1.updateScore(3, 2);
    match2.updateScore(2, 2);

    const summary = scoreBoard.summary();

    expect(summary[0]).toEqual({
      homeTeam: 'Team A',
      awayTeam: 'Team B',
      homeScore: 3,
      awayScore: 2
    });

    expect(summary[1]).toEqual({
      homeTeam: 'Team C',
      awayTeam: 'Team D',
      homeScore: 2,
      awayScore: 2
    });
  });

  test('constructor throws error when homeTeam and awayTeam are the same', () => {
    expect(() => new Match('Team A', 'Team A')).toThrowError();
  });

  test('constructor throws error when homeTeam is null', () => {
    expect(() => new Match(null, 'Team B')).toThrowError();
  });

  test('constructor throws error when awayTeam is null', () => {
    expect(() => new Match('Team A', null)).toThrowError();
  });

  test('constructor throws error when homeTeam is empty', () => {
    expect(() => new Match('', 'Team B')).toThrowError();
  });

  test('constructor throws error when awayTeam is empty', () => {
    expect(() => new Match('Team A', '')).toThrowError();
  });

  test('constructor throws error when homeTeam is whitespace', () => {
    expect(() => new Match('  ', 'Team B')).toThrowError();
  });

  test('constructor throws error when awayTeam is whitespace', () => {
    expect(() => new Match('Team A', '  ')).toThrowError();
  });
});
