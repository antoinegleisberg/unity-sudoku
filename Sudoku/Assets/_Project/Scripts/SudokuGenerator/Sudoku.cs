using UnityEngine;


[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("antoinegleisberg.SudokuGame.Editor.Tests")]
namespace antoinegleisberg.SudokuGame.SudokuGrid
{
    /// <summary>
    /// Represents a sudoku grid of given size.
    /// The instances of this class represent Sudokus that have a unique solution.
    /// </summary>
    public class Sudoku
    {
        private int size;
        private int blockWidth;
        private int[,] grid;
        private int[,] solution;

        public int Size { get { return size; } }
        public int BlockWidth { get { return blockWidth; } }
        public int BlockHeight { get { return size / blockWidth; } }
        public int[,] Grid { get { return grid; } }
        public int[,] Solution { get { return solution; } }

        public Sudoku(int size = 9, int blockWidth = 3, int difficulty = 1)
        {
            this.size = size;
            this.blockWidth = blockWidth;

            difficulty = Mathf.Clamp(difficulty, 1, 5);
            int missingDigits = 10 + 3 * difficulty;
            grid = SudokuGenerator.GenerateSudokuWithUniqueSolution(size, blockWidth, missingDigits);
            
            solution = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    solution[i, j] = grid[i, j];
                }
            }
            
            SudokuSolver.Solve(solution, blockWidth);
        }

        public int NumberAt(int x, int y) => Grid[x, y];
        public int SolutionNumberAt(int x, int y) => Solution[x, y];
        public int NumberAt(Vector2Int coords) => NumberAt(coords.x, coords.y);
        public int SolutionNumberAt(Vector2Int coords) => SolutionNumberAt(coords.x, coords.y);

        public void FillCell(int x, int y) => Grid[x, y] = Solution[x, y];
        public void FillCell(Vector2Int coords) => FillCell(coords.x, coords.y);

        public bool IsCorrect(int x, int y, int number) => Solution[x, y] == number;
        public bool IsCorrect(Vector2Int coords, int number) => IsCorrect(coords.x, coords.y, number);
    }
}
