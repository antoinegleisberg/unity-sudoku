using System.Collections.Generic;
using antoinegleisberg.Tools;

namespace antoinegleisberg.Sudoku.Generator
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
            int NROWS = grid.GetLength(0);
            int NCOLS = grid.GetLength(1);

            if (row == NROWS)
            {
                return true;
            }

            if (col == NCOLS)
            {
                return Solve(grid, row + 1, 0, blockWidth);
            }

            if (grid[row, col] != 0)
            {
                return Solve(grid, row, col + 1, blockWidth);
            }
            
            List<int> possibleNumbers = Utilities.ShuffleList(PossibleNumbers(grid, row, col, blockWidth));

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

            List<int> possibleNumbers = PossibleNumbers(grid, row, col, blockWidth);

            int result = 0;

            foreach (int number in possibleNumbers)
            {
                grid[row, col] = number;
                result += CountSolutions(grid, row, col + 1, blockWidth);
            }

            grid[row, col] = 0;

            return result;
        }

        private static List<int> PossibleNumbers(int[,] grid, int row, int col, int blockWidth)
        {
            List<int> possibleNumbers = new List<int>();

            int SIZE = grid.GetLength(0);
            int BLOCK_WIDTH = blockWidth;
            int BLOCK_HEIGHT = SIZE / BLOCK_WIDTH;
            int N_ROWS = BLOCK_WIDTH;
            int N_COLS = BLOCK_HEIGHT;

            for (int i = 1; i <= SIZE; i++)
            {
                possibleNumbers.Add(i);
            }

            for (int i = 0; i < SIZE; i++)
            {
                possibleNumbers.Remove(grid[row, i]);
                possibleNumbers.Remove(grid[i, col]);
            }

            int blockRow = row / BLOCK_HEIGHT;
            int blockCol = col / BLOCK_WIDTH;

            for (int i = 0; i < N_ROWS; i++)
            {
                int rowOffset = BLOCK_HEIGHT * blockRow + i;
                for (int j = 0; j < N_COLS; j++)
                {
                    int colOffset = BLOCK_WIDTH * blockCol + j;
                    possibleNumbers.Remove(grid[rowOffset, colOffset]);
                }
            }

            return possibleNumbers;
        }
    }
}
