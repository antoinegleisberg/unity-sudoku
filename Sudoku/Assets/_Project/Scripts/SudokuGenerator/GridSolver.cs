using System.Collections.Generic;
using antoinegleisberg.Tools;

namespace antoinegleisberg.Sudoku.GridGenerator
{
    internal static class GridSolver
    {
        public static bool SolveGrid(int[,] grid)
        {
            return SolveGrid(grid, 0, 0);
        }

        public static int CountSolutions(int[,] grid)
        {
            return CountSolutions(grid, 0, 0);
        }

        private static bool SolveGrid(int[,] grid, int row, int col)
        {
            int NROWS = grid.GetLength(0);
            int NCOLS = grid.GetLength(1);

            if (row == NROWS)
            {
                return true;
            }

            if (col == NCOLS)
            {
                return SolveGrid(grid, row + 1, 0);
            }

            if (grid[row, col] != 0)
            {
                return SolveGrid(grid, row, col + 1);
            }
            
            List<int> possibleNumbers = Utilities.ShuffleList(PossibleNumbers(grid, row, col));

            foreach (int number in possibleNumbers)
            {
                grid[row, col] = number;
                if (SolveGrid(grid, row, col + 1))
                {
                    return true;
                }
            }

            grid[row, col] = 0;

            return false;
        }

        private static int CountSolutions(int[,] grid, int row, int col)
        {
            int NROWS = grid.GetLength(0);
            int NCOLS = grid.GetLength(1);

            if (row == NROWS)
            {
                return 1;
            }

            if (col == NCOLS)
            {
                return CountSolutions(grid, row + 1, 0);
            }

            if (grid[row, col] != 0)
            {
                return CountSolutions(grid, row, col + 1);
            }

            List<int> possibleNumbers = PossibleNumbers(grid, row, col);

            int result = 0;

            foreach (int number in possibleNumbers)
            {
                grid[row, col] = number;
                result += CountSolutions(grid, row, col + 1);
            }

            grid[row, col] = 0;

            return result;
        }

        private static List<int> PossibleNumbers(int[,] grid, int row, int col)
        {
            List<int> possibleNumbers = new List<int>();

            for (int i = 1; i <= 9; i++)
            {
                possibleNumbers.Add(i);
            }

            for (int i = 0; i < 9; i++)
            {
                possibleNumbers.Remove(grid[row, i]);
                possibleNumbers.Remove(grid[i, col]);
            }

            int blockRow = row / 3;
            int blockCol = col / 3;

            for (int i = 0; i < 3; i++)
            {
                int rowOffset = 3 * blockRow + i;
                for (int j = 0; j < 3; j++)
                {
                    int colOffset = 3 * blockCol + j;
                    possibleNumbers.Remove(grid[rowOffset, colOffset]);
                }
            }

            return possibleNumbers;
        }
    }
}
