


using System;

namespace ChessKnightGame
{
    // <summary>
    // Represents a chessboard and a chess knight.
    // The goal of the game is to move the knight to visit all the squares on the board without revisiting any square.
    // </summary>
    public class ChessKnight
    {
        private const int BoardSize = 8;
        private int[,] board;
        private int currentRow;
        private int currentCol;
        private int movesCount;

        // <summary>
        // Constructs a new ChessKnight object and initializes the chessboard.
        // </summary>
        public ChessKnight()
        {
            board = new int[BoardSize, BoardSize];
            currentRow = 0;
            currentCol = BoardSize - 1;
            movesCount = 1;
        }

        // <summary>
        // Starts the game and allows the user to play.
        // </summary>
        public void StartGame()
        {
            Console.WriteLine("Welcome to the Chess Knight game!");

            while (true)
            {
                Console.WriteLine("Current board:");
                PrintBoard();

                Console.WriteLine("Enter your move (1-8):");
                int move = GetValidMove();

                if (!MakeMove(move))
                {
                    Console.WriteLine("Invalid move! You have already visited that square.");
                    Console.WriteLine("Do you want to start again? (Y/N)");
                    string restart = Console.ReadLine();

                    if (restart.ToUpper() == "Y")
                    {
                        ResetGame();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                if (movesCount == BoardSize * BoardSize)
                {
                    Console.WriteLine("Congratulations! You have visited all the squares without revisiting any square.");
                    Console.WriteLine("Do you want to play again? (Y/N)");
                    string playAgain = Console.ReadLine();

                    if (playAgain.ToUpper() == "Y")
                    {
                        ResetGame();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("Thank you for playing the Chess Knight game!");
        }

        // <summary>
        // Prints the current state of the chessboard.
        // </summary>
        private void PrintBoard()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    Console.Write(board[row, col].ToString().PadLeft(3));
                }
                Console.WriteLine();
            }
        }

        // <summary>
        // Validates and returns a valid move entered by the user.
        // </summary>
        private int GetValidMove()
        {
            int move;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out move) && move >= 1 && move <= 8)
                {
                    return move;
                }
                else
                {
                    Console.WriteLine("Invalid move! Please enter a number between 1 and 8.");
                }
            }
        }

        // <summary>
        // Makes a move on the chessboard.
        // </summary>
        // <param name="move">The move to be made.</param>
        // <returns>True if the move is valid and the square has not been visited before, false otherwise.</returns>
        private bool MakeMove(int move)
        {
            int newRow = currentRow;
            int newCol = currentCol;

            switch (move)
            {
                case 1:
                    newRow -= 2;
                    newCol += 1;
                    break;
                case 2:
                    newRow -= 1;
                    newCol += 2;
                    break;
                case 3:
                    newRow += 1;
                    newCol += 2;
                    break;
                case 4:
                    newRow += 2;
                    newCol += 1;
                    break;
                case 5:
                    newRow += 2;
                    newCol -= 1;
                    break;
                case 6:
                    newRow += 1;
                    newCol -= 2;
                    break;
                case 7:
                    newRow -= 1;
                    newCol -= 2;
                    break;
                case 8:
                    newRow -= 2;
                    newCol -= 1;
                    break;
            }

            if (newRow >= 0 && newRow < BoardSize && newCol >= 0 && newCol < BoardSize && board[newRow, newCol] == 0)
            {
                board[newRow, newCol] = movesCount + 1;
                currentRow = newRow;
                currentCol = newCol;
                movesCount++;
                return true;
            }

            return false;
        }

        // <summary>
        // Resets the game by clearing the chessboard and resetting the knight's position.
        // </summary>
        private void ResetGame()
        {
            board = new int[BoardSize, BoardSize];
            currentRow = 0;
            currentCol = BoardSize - 1;
            movesCount = 1;
        }
    }

    // Example program for ChessKnight class.
    public class Program
    {
        public static void Main()
        {
            var chessKnight = new ChessKnight();
            chessKnight.StartGame();
        }
    }
}