# Schneider Electric Minefield Game
Welcome to the Schneider Electric Minefield Game! This is a console-based implementation of a Minesweeper-style game where the player must navigate from one side of the board to the other while avoiding hidden mines.

## Features
- **Dynamic Board Size:** Configurable board size through appsettings.json (default: 8x8).
- **Random Mine Placement:** Configurable number of mines through appsettings.json (default: 10).
- **Simple Console Interface:** Navigate using arrow keys (up, down, left, right).
- **Lives and Moves Counter:** Tracks your progress and remaining lives.
- **Dependency Injection:** Clean architecture with flexibility for future enhancements.

## Getting Started
### Prerequisites
To run the project, ensure you have the following installed:
- **.NET 8 SDK** or higher
- A text editor (e.g., Visual Studio, VS Code) or terminal for running the application

### Setup Instructions
1. Clone the repository:
```bash
git clone https://github.com/smalezic/schneider-electric.git
cd schneider-electric/SchneiderElectric.Minefield.Host
```
2. Restore dependencies:
```bash
dotnet restore
```
3. Update game settings in `appsettings.json` (optional):
   - `BoardSize`: Defines the size of the board (minimum: 4, maximum: 9)
   - `NumberOfMines`: Defines the number of hidden mines (minimum: 1, maximum: BoardSize * BoardSize / 2)
4. Run the application
```bash
dotnet run
```

## How to play
1. **Objective:** Navigate from the top-left corner (`A8`) to the bottom-right corner (`H1`) while avoiding mines.
2. **Controls:**
   - Use **arrow keys** to move
   - Avoid invalid moves, stay within the board boundaries.
3. **Indicators:**
   - `O`: Player's current position
   - `-`: Unrevealed empty space
   - Mines are hidden until you step on one or the game ends
4. **Game Over:**
   - **Win:** Reach the bottom-right corner of the board
   - **Lose:** Run out of lives before reaching the goal
