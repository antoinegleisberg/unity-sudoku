using System.Collections.Generic;
using antoinegleisberg.Tools;


namespace antoinegleisberg.SudokuGame.SudokuGrid
{
    internal static class SudokuSolver
    {
        public static bool Solve(int[,] grid, int blockWidth)
        {
            return Solve(grid, 0, 0, blockWidth);
        }

        public static int CountSolutions(int[,] grid, int blockWidth)
        {
            return CountSolutions(grid, 0, 0, blockWidth);
        }

        private static bool Solve(int[,] grid, int row, int col, int blockWidth)
        {
            int SIZE = grid.GetLength(0);

            if (row == SIZE)
            {
                return true;
            }

            if (col == SIZE)
            {
                return Solve(grid, row + 1, 0, blockWidth);
            }

            if (grid[row, col] != 0)
            {
                return Solve(grid, row, col + 1, blockWidth);
            }
            
            List<int> possibleNumbers = ListUtilities.Shuffle(SudokuUtilities.PossibleNumbers(grid, row, col, blockWidth));

            foreach (int number in possibleNumbers)
            {
                grid[row, col] = number;
                if (Solve(grid, row, col + 1, blockWidth))
                {
                    return true;
                }
            }

            grid[row, col] = 0;

            return false;
        }

        private static int CountSolutions(int[,] grid, int row, int col, int blockWidth)
        {
            int SIZE = grid.GetLength(0);

            if (row == SIZE)
            {
                return 1;
            }

            if (col == SIZE)
            {
                return CountSolutions(grid, row + 1, 0, blockWidth);
            }

            if (grid[row, col] != 0)
            {
                return CountSolutions(grid, row, col + 1, blockWidth);
            }

            List<int> possibleNumbers = SudokuUtilities.PossibleNumbers(grid, row, col, blockWidth);

            int result = 0;

            foreach (int number in possibleNumbers)
            {
                grid[row, col] = number;
                result += CountSolutions(grid, row, col + 1, blockWidth);
            }

            grid[row, col] = 0;

            return result;
        }
    }
}
