```
 _____                           _                              _ 
/  ___|                         | |                            | |
\ `--.   ___   ___   _ __   ___ | |__    ___    __ _  _ __   __| |
 `--. \ / __| / _ \ | '__| / _ \| '_ \  / _ \  / _` || '__| / _` |
/\__/ /| (__ | (_) || |   |  __/| |_) || (_) || (_| || |   | (_| |
\____/  \___| \___/ |_|    \___||_.__/  \___/  \__,_||_|    \__,_|
                                                                                                                                
                     ___
 o__        o__     |   |\
/|          /\      |   |X\
/ > o        <\     |   |XX\

```

# Scoreboard Application

This application provides a simple score-tracking system for matches. The application was developed using the Test-Driven Development (TDD) methodology.

## Overview

The application consists of two main classes:

- `Match` class: Represents a match with home and away teams and their respective scores.
- `Scoreboard` class: Manages the matches, allowing to start a match, finish a match, and get a summary of matches.

## How to Test

Please ensure that you have the necessary environments set up for TypeScript and .NET before running the tests (Node.js and npm for TypeScript, and .NET SDK for .NET).

Here are the instructions to test the application for both TypeScript and .NET:

### Testing TypeScript
Navigate to the TypeScript directory and run the tests using npm:

```bash
cd TypeScript
npm install
npm run test
npm run coverage
```

### Testing .NET (C#)
Navigate to the .NET testing project directory and run the tests using the dotnet test command:

```bash
cd DotNet
cd ScoreboardApp.Tests
dotnet test
```

## Usage Scenarios

Here are some key scenarios that the Scoreboard application is designed to handle:

### Scenario: Start a New Match

- Given a new scoreboard
- When I start a match between "Team A" and "Team B"
- Then the match should be added to the scoreboard with score 0 - 0

### Scenario: Update Score

- Given a match between "Team A" and "Team B"
- When I update the score to 3 - 2
- Then the score for "Team A" vs "Team B" should be 3 - 2

### Scenario: Finish Match

- Given a match between "Team A" and "Team B" on the scoreboard
- When I finish the match
- Then the match should be removed from the scoreboard

### Scenario: Get a Summary of Matches

- Given the following matches:

  | Home Team | Away Team | Home Score | Away Score |
  |---        |---        |---         |---         |
  | Team A    | Team B    | 3          | 2          |
  | Team C    | Team D    | 2          | 2          |

- When I get the summary
- Then the summary should be:

  | Home Team | Away Team | Home Score | Away Score |
  |---        |---        |---         |---         |
  | Team A    | Team B    | 3          | 2          |
  | Team C    | Team D    | 2          | 2          |

## Object-Oriented Design

The application follows the principles of Object-Oriented Programming (OOP). The `Match` class encapsulates the state and behaviors related to a match, and the `Scoreboard` class manages multiple `Match` objects and provides additional functionalities.

Here is a UML class diagram illustrating the relationship:

```
  +----------------------------------------------------------+
  | Scoreboard                                               |
  +----------------------------------------------------------+
  | -matches: Match[]                                        |
  +----------------------------------------------------------+
  | +startMatch(homeTeam: string, awayTeam: string): Match   |
  | +finishMatch(match: Match): void                         |
  | +summary(): MatchSummary[]                               |
  +----------------------------------------------------------+
                              1
                              |
                              | *
  +----------------------------------------------------------+
  | Match                                                    |
  +----------------------------------------------------------+
  | -homeTeam: string                                        |
  | -awayTeam: string                                        |
  | -homeScore: number                                       |
  | -awayScore: number                                       |
  | -startTime: DateTime                                     |
  +----------------------------------------------------------+
  | +constructor(homeTeam: string, awayTeam: string)         |
  | +updateScore(homeScore: number, awayScore: number): void |
  | +totalScore(): number                                    |
  +----------------------------------------------------------+
```

Please see the code for further implementation details.
