using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace antoinegleisberg.Sudoku.GridGenerator
{
    internal static class GridGenerator
    {
        public static int[,] GenerateEmptyGrid(int width = 9, int height = 9)
        {
            int[,] grid = new int[width, height];

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    grid[row, col] = 0;
                }
            }

            return grid;
        }

        public static int[,] GenerateFullGrid(int width = 9, int height = 9)
        {
            int[,] grid = GenerateEmptyGrid();

            GridSolver.SolveGrid(grid);

            return grid;
        }

        public static int[,] GenerateSudokuWithUniqueSolution(int missingDigits)
        {
            int[,] grid = GenerateSudoku(missingDigits);

            while (GridSolver.CountSolutions(grid) != 1)
            {
                grid = GenerateSudoku(missingDigits);
            }

            return grid;
        }

        private static int[,] GenerateSudoku(int missingDigits)
        {
            int[,] grid = GenerateFullGrid();

            for (int i = 0; i < missingDigits; i++)
            {
                int row = Random.Range(0, 9);
                int col = Random.Range(0, 9);

                while (grid[row, col] == 0)
                {
                    row = Random.Range(0, 9);
                    col = Random.Range(0, 9);
                }

                grid[row, col] = 0;
            }

            return grid;
        }
    }
}
