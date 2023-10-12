using UnityEngine;

namespace antoinegleisberg.SudokuGame.SudokuGrid
{
    internal static class SudokuGenerator
    {
        public static int[,] GenerateEmpty(int gridSize = 9)
        {
            int[,] grid = new int[gridSize, gridSize];

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    grid[row, col] = 0;
                }
            }

            return grid;
        }

        public static int[,] GenerateFull(int gridSize = 9, int blockWidth = 3)
        {
            int[,] grid = GenerateEmpty(gridSize);

            SudokuSolver.Solve(grid, blockWidth);

            return grid;
        }

        public static int[,] GenerateSudokuWithUniqueSolution(int gridSize, int blockWidth, int missingDigits)
        {
            int[,] grid = Generate(gridSize, blockWidth, missingDigits);

            while (SudokuSolver.CountSolutions(grid, blockWidth) != 1)
            {
                grid = Generate(gridSize, blockWidth, missingDigits);
            }

            return grid;
        }

        private static int[,] Generate(int size, int blockWidth, int missingDigits)
        {
            int[,] grid = GenerateFull(size, blockWidth);

            for (int i = 0; i < missingDigits; i++)
            {
                int row = Random.Range(0, size);
                int col = Random.Range(0, size);

                while (grid[row, col] == 0)
                {
                    row = Random.Range(0, size);
                    col = Random.Range(0, size);
                }

                grid[row, col] = 0;
            }

            return grid;
        }
    }
}
