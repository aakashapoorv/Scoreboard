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

### Approach followed:- 

1. Write a failing test case (Red)
2. Write the minimum amount of code needed to make the test pass (Green)
3. Refactor the code, if necessary, to improve the structure while maintaining the behavior (Refactor)

[Commit History](https://github.com/aakashapoorv/Scoreboard/commits/main)


## Overview

The application consists of two main classes:

- `Match` class: Represents a match with home and away teams and their respective scores.
- `Scoreboard` class: Manages the matches, allowing to start a match, finish a match, and get a summary of matches.

### Structure

```bash
.
├── DotNet
│   ├── LICENSE
│   ├── ScoreboardApp
│   │   ├── Match.cs
│   │   ├── Program.cs
│   │   ├── ScoreBoard.cs
│   │   └── ScoreboardApp.csproj
│   └── ScoreboardApp.Tests
│       ├── ScoreBoardTests.cs
│       ├── ScoreboardApp.Tests.csproj
│       └── Usings.cs
├── LICENSE
├── README.md
└── TypeScript
    ├── LICENSE
    ├── jest.config.js
    ├── match.ts
    ├── package-lock.json
    ├── package.json
    ├── scoreboard.test.ts
    └── scoreboard.ts
```

## Features

- **Start a new match**: The application allows you to start a new match with the given home and away teams, assuming an initial score of 0 - 0.
- **Update score**: The application allows you to update the score of a match.
- **Finish match**: The application allows you to finish a match currently in progress.
- **Get a summary of matches**: The application allows you to get a summary of matches in progress, ordered by their total score.

## Getting Started

These instructions will help you get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [.NET 7.0](https://dotnet.microsoft.com/en-us/download)
- [Node.js 18.17.0](https://nodejs.org/en/download)

### Setting Up the Project

1. Clone the repository to your local machine:

```bash
git clone https://github.com/aakashapoorv/Scoreboard.git
```

2. Navigate into the project directory:

```bash
cd Scoreboard
```


## How to Test

Please ensure that you have the necessary environments set up for TypeScript and .NET before running the tests (Node.js and npm for TypeScript, and .NET SDK for .NET).

Here are the instructions to test the application for both TypeScript and .NET:

### Testing TypeScript
Navigate to the TypeScript directory and run the tests using npm:

Change the directory to `TypeScript`.

```bash
cd TypeScript
```

Install dependencies using `npm`.

```bash
npm install
```

Run tests with `npm`.

```bash
npm run test
```

Generate test coverage with `npm`.

```bash
npm run coverage
```

### Testing .NET (C#)
Navigate to the .NET testing project directory and run the tests using the dotnet test command:

Change the directory to `DotNet`.

```bash
cd DotNet
```

Change the directory to `ScoreboardApp.Tests`.

```bash
cd ScoreboardApp.Tests
```

Run tests with `dotnet`.

```bash
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

1. **Scalability**: If the number of matches or frequency of score updates is extremely high, we might need a more efficient way to store and retrieve match data.
 
2. **Concurrency**: If multiple threads or processes are trying to update scores or retrieve match summaries at the same time, we would need to add synchronization to prevent data races or inconsistencies.
  
3. **Persistence**: Currently, all match data is lost when the program ends. If we needed to store match data across multiple runs of the program, we'd need a way to persist match data to a file, database, or other data store.
  
4. **Networking**: If we needed to update scores or retrieve summaries from a remote client, we'd need to add networking code and likely restructure our classes to fit a client-server model.

5. **Error handling**: The code contains extensive error handling to account for a variety of edge cases. This includes checking for null or empty team names, ensuring that home and away teams are not the same, disallowing negative scores, preventing score updates after a match has ended, and handling situations where a match is started or ended multiple times. These checks ensure that the scoreboard operates correctly and robustly in a wide range of situations. This level of error handling is essential for any complex system, and has been integrated here in a way that does not obscure the main logic of the program.

6. **Modularity and Extensibility**: If more features or complexity were anticipated, we might need a more modular design with more abstractions. For example, we might have an abstract `Match` class with different subclasses for different sports, or we could use interfaces to allow different types of score storage (in-memory, database, etc.).

## Edge cases

1. **Null or Empty Team Names:** The names for the home and away teams must be provided, and they can't be null or empty.

2. **Same Team Names:** The names of the home and away teams should not be the same.

3. **Negative Scores:** The scores for the home and away teams can't be negative.

4. **Lower Scores than Previous:** The scores for the home and away teams should not be lower than the previously recorded scores.

5. **Score Updates after the Match Ends:** Updates to the scores should not be allowed once the match has ended.

6. **Starting a Match that has Already Started:** A match that has already started cannot be started again.

7. **Finishing a Match that has Already Ended:** A match that has already ended cannot be finished again.

8. **Starting and Finishing a Match Simultaneously:** A match cannot be started and finished at the same time. 

9. **Non-existent matches**: When trying to finish a match that doesn't exist or has already been finished and removed from the `ScoreBoard`, the application should handle this gracefully.

10. **Highly concurrent updates**: If the system is designed to be used in a multithreaded or distributed environment, the application should correctly handle many concurrent score updates, starts, and finishes.

## SOLID principles

1. **Single Responsibility Principle (SRP)**: This principle states that a class should have only one reason to change. In the Scoreboard application, the `Match` class is responsible for holding the information about a match, and the `ScoreBoard` class is responsible for managing the matches (starting a match, finishing a match, updating the score, and providing a summary). Each class has a single responsibility.

2. **Open/Closed Principle (OCP)**: This principle states that a software entity should be open for extension, but closed for modification. While the Scoreboard application doesn't necessarily showcase this principle as there are no obvious extensions we are looking to make, the design does not prevent it. For example, if we were to add new properties to the `Match` class or add new operations to the `ScoreBoard`, we could do so without having to modify existing methods. 

3. **Liskov Substitution Principle (LSP)**: This principle states that if a program is using a base class, it should be able to use any of its subclasses without the program knowing it. The Scoreboard application does not explicitly demonstrate this principle as we are not currently using inheritance or polymorphism.

4. **Interface Segregation Principle (ISP)**: This principle states that clients should not be forced to depend on interfaces they do not use. The Scoreboard application demonstrates this principle by not forcing any classes to implement unnecessary methods or properties. Since the current design doesn't make use of explicit interfaces, this principle is only indirectly relevant.

5. **Dependency Inversion Principle (DIP)**: This principle states that high-level modules should not depend on low-level modules, but both should depend on abstractions. In the Scoreboard application, we don't have clear high-level and low-level modules, nor do we have explicit dependencies. If we were to add more complexity to our system, such as a database or UI component, we would want to depend on abstractions (like interfaces) rather than concretions.

## Clean Code

1. **Meaningful names**: The class and variable names in the code (`ScoreBoard`, `Match`, `HomeTeam`, `AwayTeam`, etc.) are descriptive and give a clear indication of their roles and responsibilities. 

2. **Functions do one thing**: The functions in this code each have a single, well-defined task. For example, `StartMatch` only starts a match, `UpdateScore` only updates the score, etc.

3. **Small functions**: All functions are quite small and focused, making them easy to understand and test.

4. **Proper use of comments**: In this case, the code is self-explanatory and doesn't use comments. Clean Code suggests that code should be written in a way that makes comments unnecessary as much as possible. 

5. **Formatting**: The code is consistently formatted, which makes it easy to read.

6. **No duplication**: The DRY (Don't Repeat Yourself) principle is followed in this code. There is no repetition or unnecessary information.

7. **Error handling**: The code contains extensive error handling to account for a variety of edge cases. This includes checking for null or empty team names, ensuring that home and away teams are not the same, disallowing negative scores, preventing score updates after a match has ended, and handling situations where a match is started or ended multiple times. These checks ensure that the scoreboard operates correctly and robustly in a wide range of situations. This level of error handling is essential for any complex system, and has been integrated here in a way that does not obscure the main logic of the program.

8. **No unnecessary classes or methods**: The code doesn't have any classes, methods, or variables that aren't needed.

## Built With

- [.NET 7.0](https://dotnet.microsoft.com/en-us/download)
- [Node.js 18.17.0](https://nodejs.org/en/download)


## Authors

- **Aakash Apoorv**

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
