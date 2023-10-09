

using System.Collections.Generic;
using UnityEngine;

namespace antoinegleisberg.Sudoku.GridGenerator
{
    public static class GridUtilities
    {
        private static readonly Dictionary<int, int> _difficultyToMissingDigits = new Dictionary<int, int>()
        {
            {1, 20 },
            {2, 30 },
            {3, 40 },
            {4, 50 },
            {5, 60 }
        };

        public static int[,] GenerateEmptyGrid(int width = 9, int height = 9)
        {
            return GridGenerator.GenerateEmptyGrid(width, height);
        }

        public static int[,] GenerateFullGrid(int width = 9, int height = 9)
        {
            return GridGenerator.GenerateFullGrid(width, height);
        }

        public static bool SolveGrid(int[,] grid)
        {
            return GridSolver.SolveGrid(grid);
        }

        public static int CountSolutions(int[,] grid)
        {
            return GridSolver.CountSolutions(grid);
        }

        public static int[,] GeneratePuzzle(int difficulty = 1)
        {
            difficulty = Mathf.Clamp(difficulty, 1, 5);
            return GridGenerator.GenerateSudokuWithUniqueSolution(_difficultyToMissingDigits[difficulty]);
        }
    }
}
