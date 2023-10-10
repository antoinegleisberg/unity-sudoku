using System.Collections.Generic;
using UnityEngine;

namespace antoinegleisberg.Sudoku.Generator
{
    public static class SudokuUtilities
    {
        private static readonly Dictionary<int, int> _difficultyToMissingDigits = new Dictionary<int, int>()
        {
            {1, 20 },
            {2, 30 },
            {3, 40 },
            {4, 50 },
            {5, 60 }
        };

        public static int[,] GenerateEmptyGrid(int gridSize = 9)
        {
            return SudokuGenerator.GenerateEmpty(gridSize);
        }

        public static int[,] GenerateFullGrid(int gridSize = 9, int blockWidth = 3)
        {
            return SudokuGenerator.GenerateFull(gridSize, blockWidth);
        }

        public static bool SolveGrid(int[,] grid, int blockWidth = 3)
        {
            return SudokuSolver.Solve(grid, blockWidth);
        }

        public static int CountSolutions(int[,] grid, int blockWidth)
        {
            return SudokuSolver.CountSolutions(grid, blockWidth);
        }

        public static int[,] GeneratePuzzle(int difficulty = 1, int size = 9, int blockWidth = 3)
        {
            difficulty = Mathf.Clamp(difficulty, 1, 5);
            return SudokuGenerator.GenerateSudokuWithUniqueSolution(size, blockWidth, _difficultyToMissingDigits[difficulty]);
        }
    }
}
