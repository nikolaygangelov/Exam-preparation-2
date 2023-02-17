using System;

namespace _NavyBattle
{
    class NavyBattle
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int indexOfRows = 0;
            int indexOfCols = 0;

            for (int row = 0; row < n; row++)
            {
                string inputOfMatrix = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    if (inputOfMatrix[col] == 'S')
                    {
                        indexOfRows = row;
                        indexOfCols = col;
                        matrix[row, col] = '-';
                        continue;
                    }
                    matrix[row, col] = inputOfMatrix[col];
                }
            }
            int countOfMines = 0;
            int countOfCruisers = 0;
            while (countOfMines < 3 && countOfCruisers < 3)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        indexOfRows--;
                        if (matrix[indexOfRows, indexOfCols] == '*')
                        {
                            countOfMines++;
                            matrix[indexOfRows, indexOfCols] = '-';
                        }
                        else if (matrix[indexOfRows, indexOfCols] == 'C')
                        {
                            countOfCruisers++;
                            matrix[indexOfRows, indexOfCols] = '-';
                        }
                        break;
                    case "down":
                        indexOfRows++;
                        if (matrix[indexOfRows, indexOfCols] == '*')
                        {
                            countOfMines++;
                            matrix[indexOfRows, indexOfCols] = '-';
                        }
                        else if (matrix[indexOfRows, indexOfCols] == 'C')
                        {
                            countOfCruisers++;
                            matrix[indexOfRows, indexOfCols] = '-';
                        }
                        break;
                    case "left":
                        indexOfCols--;
                        if (matrix[indexOfRows, indexOfCols] == '*')
                        {
                            countOfMines++;
                            matrix[indexOfRows, indexOfCols] = '-';
                        }
                        else if (matrix[indexOfRows, indexOfCols] == 'C')
                        {
                            countOfCruisers++;
                            matrix[indexOfRows, indexOfCols] = '-';
                        }
                        break;
                    case "right":
                        indexOfCols++;
                        if (matrix[indexOfRows, indexOfCols] == '*')
                        {
                            countOfMines++;
                            matrix[indexOfRows, indexOfCols] = '-';
                        }
                        else if (matrix[indexOfRows, indexOfCols] == 'C')
                        {
                            countOfCruisers++;
                            matrix[indexOfRows, indexOfCols] = '-';
                        }
                        break;
                    default:
                        break;
                }
            }

            if (countOfMines == 3)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{indexOfRows}, {indexOfCols}]!");
            }

            if (countOfCruisers == 3)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            }

            PrintMatrix(matrix, indexOfRows, indexOfCols);
        }

        public static void PrintMatrix(char[,] matrix, int indexOfRows, int indexOfCols)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == indexOfRows && col == indexOfCols)
                    {
                        Console.Write('S');
                    }
                    else
                    {
                        Console.Write($"{matrix[row, col]}");
                    }

                }
                Console.WriteLine();
            }
        }

    }
}
