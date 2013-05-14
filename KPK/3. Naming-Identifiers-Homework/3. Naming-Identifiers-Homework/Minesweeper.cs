using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Minesweeper
{
    public class Engine
    {
        public class Score
        {
            private string name;
            private int points;

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            public int Points
            {
                get { return this.points; }
                set { this.points = value; }
            }

            public Score() { }

            public Score(string name, int points)
            {
                this.name = name;
                this.points = points;
            }
        }

        private const int MAX_SIZE_OF_FIELD = 35;

        static void Main(string[] arguments)
        {
            string command = string.Empty;
            char[,] gameField = CreateField();
            char[,] bombs = CreateBombs();
            int actionCounter = 0;
            bool hitMine = false;
            List<Score> topScores = new List<Score>(6);
            int row = 0;
            int column = 0;

            bool initialization = true;
            bool gameIsWon = false;

            do
            {
                if (initialization)
                {
                    HelpMenu();
                    Console.Write("Press the \"any\" key to continue.");
                    Console.ReadKey();
                    DrawField(gameField);
                    initialization = false;
                }

                Console.Write("Enter \"<x>\" \"<y>\" coordiantes or a command: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out column))
                    {
                        if (row < gameField.GetLength(0) && column < gameField.GetLength(1))
                        {
                            command = "turn";
                        }
                        else
                        {
                            command = "InvalidCoordinate";
                        }
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintScores(topScores);
                        break;
                    case "restart":
                        gameField = CreateField();
                        bombs = CreateBombs();
                        DrawField(gameField);
                        hitMine = false;
                        initialization = false;
                        Console.Clear();
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                PlayerAction(gameField, bombs, row, column);
                                actionCounter++;
                            }
                            if (MAX_SIZE_OF_FIELD == actionCounter)
                            {
                                gameIsWon = true;
                            }
                            else
                            {
                                DrawField(gameField);
                            }
                        }
                        else
                        {
                            hitMine = true;
                        }
                        break;
                    case "InvalidCoordinate":
                        Console.WriteLine("\nInvalid coordinate!\n");
                        break;
                    case "help":
                        HelpMenu();
                        break;
                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }
                if (hitMine)
                {
                    DrawField(bombs);
                    Console.Write("\nYou have ended your game with {0} actions. " +
                    "Enter your nickname : ", actionCounter);
                    string nickname = Console.ReadLine();
                    Score curowentScore = new Score(nickname, actionCounter);
                    if (topScores.Count < 5)
                    {
                        topScores.Add(curowentScore);
                    }
                    else
                    {
                        for (int i = 0; i < topScores.Count; i++)
                        {
                            if (topScores[i].Points < curowentScore.Points)
                            {
                                topScores.Insert(i, curowentScore);
                                topScores.RemoveAt(topScores.Count - 1);
                                break;
                            }
                        }
                    }
                    topScores.Sort((Score firstScore, Score secondScore) => secondScore.Name.CompareTo(firstScore.Name));
                    topScores.Sort((Score firstScore, Score secondScore) => secondScore.Points.CompareTo(firstScore.Points));

                    PrintScores(topScores);

                    gameField = CreateField();
                    bombs = CreateBombs();
                    actionCounter = 0;
                    hitMine = false;
                    initialization = true;
                }
                if (gameIsWon)
                {
                    Console.WriteLine("\nCongratulations you made it through the mine field!");
                    DrawField(bombs);
                    Console.WriteLine("Enter your nickname: ");
                    string nickName = Console.ReadLine();
                    Score curowentScore = new Score(nickName, actionCounter);
                    topScores.Add(curowentScore);
                    PrintScores(topScores);
                    gameField = CreateField();
                    bombs = CreateBombs();
                    actionCounter = 0;
                    gameIsWon = false;
                    initialization = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.Read();
        }

        private static void PrintScores(List<Score> topScores)
        {
            Console.WriteLine("\nTop scores:");
            if (topScores.Count > 0)
            {
                for (int i = 0; i < topScores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} actions taken",
                    i + 1, topScores[i].Name, topScores[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No scores found!!\n");
            }
        }

        private static void PlayerAction(char[,] gameField,
        char[,] bombs, int row, int column)
        {
            char bombsAmount = GetBombs(bombs, row, column);
            bombs[row, column] = bombsAmount;
            gameField[row, column] = bombsAmount;
        }

        private static void DrawField(char[,] board)
        {
            Console.Clear();
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine(" ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine(" ---------------------\n");
        }

        private static char[,] CreateField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }
            return board;
        }

        private static char[,] CreateBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] gameField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> bombs = new List<int>();
            while (bombs.Count < 15)
            {
                Random random = new Random();
                int curowentBombPosition = random.Next(50);
                if (!bombs.Contains(curowentBombPosition))
                {
                    bombs.Add(curowentBombPosition);
                }
            }

            foreach (int bombPosition in bombs)
            {
                int column = (bombPosition / columns);
                int row = (bombPosition % columns);
                if (row == 0 && bombPosition != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }
                gameField[column, row - 1] = '*';
            }

            return gameField;
        }

        private static void CheckForMine(char[,] gameField)
        {
            int column = gameField.GetLength(0);
            int row = gameField.GetLength(1);

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (gameField[i, j] != '*')
                    {
                        char symbolOnLocation = GetBombs(gameField, i, j);
                        gameField[i, j] = symbolOnLocation;
                    }
                }
            }
        }

        private static char GetBombs(char[,] gameField, int row, int column)
        {
            int bombsCount = 0;
            int rows = gameField.GetLength(0);
            int columns = gameField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (gameField[row - 1, column] == '*')
                {
                    bombsCount++;
                }
            }
            if (row + 1 < rows)
            {
                if (gameField[row + 1, column] == '*')
                {
                    bombsCount++;
                }
            }
            if (column - 1 >= 0)
            {
                if (gameField[row, column - 1] == '*')
                {
                    bombsCount++;
                }
            }
            if (column + 1 < columns)
            {
                if (gameField[row, column + 1] == '*')
                {
                    bombsCount++;
                }
            }
            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (gameField[row - 1, column - 1] == '*')
                {
                    bombsCount++;
                }
            }
            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (gameField[row - 1, column + 1] == '*')
                {
                    bombsCount++;
                }
            }
            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (gameField[row + 1, column - 1] == '*')
                {
                    bombsCount++;
                }
            }
            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (gameField[row + 1, column + 1] == '*')
                {
                    bombsCount++;
                }
            }
            return char.Parse(bombsCount.ToString());
        }

        private static void HelpMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Lets play some \"Minesweeper!\". Test your luck to find the fields without mines.");
            Console.WriteLine("Commands:");
            Console.WriteLine("'top' shows the highscores;");
            Console.WriteLine("'restart' restarts the game;");
            Console.WriteLine("'exit' exits the game;");
            Console.WriteLine("'help' to show this info!");
            Console.WriteLine();
        }
    }
}