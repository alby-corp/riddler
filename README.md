# Riddler
The Riddler project has been conceived as a valuable educational resource aimed at providing a series of instructional exercises to allow those who undertake them to expand their skills in C#.

## Structure
The project structure dictates that each puzzle within the solution refers to three projects, of which two must remain unchanged and serve as supporting projects, while the third contains the actual puzzle question. 

The two immutable projects are:
- **Riddler.API:** This project represents a minimal API application.
- **Riddler.Shared:** It contains the models shared between the API and the project containing the puzzle.

The third project, always named **Riddler.Puzzle** followed by the _puzzle number_, hosts a Markdown file where you can read the question proposed for each puzzle.

## API Usage
To simplify the use of the tool, a **PowerShell Script** named _publish.api.ps1_ has been created. This script generates a folder named _dist.api_ containing the executable required to run the **API** locally.

## Puzzles

- [Puzzle 1](https://github.com/alby-corp/riddler/tree/main/src/Riddler.Puzzle1)