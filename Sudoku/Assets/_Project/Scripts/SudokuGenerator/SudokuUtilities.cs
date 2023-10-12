using System.Collections.Generic;
using UnityEngine;
using antoinegleisberg.Tools;
using System;

namespace antoinegleisberg.SudokuGame.SudokuGrid
{
    internal static class SudokuUtilities
    {
        public static bool RowIsValid(int[,] grid, int index)
        {
            int SIZE = grid.GetLength(0);
            List<int> row = new List<int>();

            for (int i = 0; i < SIZE; i++)
            {
                if (grid[index, i] != 0)
                {
                    row.Add(grid[index, i]);
                }
            }

            return !ListUtilities.ContainsDuplicates(row);
        }

        public static bool ColumnIsValid(int[,] grid, int index)
        {
            int SIZE = grid.GetLength(0);
            List<int> col = new List<int>();

            for (int j = 0; j < SIZE; j++)
            {
                if (grid[j, index] != 0)
                {
                    col.Add(grid[j, index]);
                }
            }

            return !ListUtilities.ContainsDuplicates(col);
        }

        public static bool BlockIsValid(int[,] grid, int rowIndex, int colIndex, int blockWidth)
        {
            int SIZE = grid.GetLength(0);
            int blockHeight = SIZE / blockWidth;
            List<int> block = new List<int>();

            for (int i = 0; i < blockWidth; i++)
            {
                for (int j = 0; j < blockHeight; j++)
                {
                    int row = blockHeight * rowIndex + i;
                    int col = blockWidth * colIndex + j;
                    if (grid[row, col] != 0)
                    {
                        block.Add(grid[row, col]);
                    }
                }
            }

            return !ListUtilities.ContainsDuplicates(block);
        }

        public static List<int> PossibleNumbers(int[,] grid, int row, int col, int blockWidth)
        {
            List<int> possibleNumbers = new List<int>();

            int SIZE = grid.GetLength(0);
            int BLOCK_WIDTH = blockWidth;
            int BLOCK_HEIGHT = SIZE / BLOCK_WIDTH;

            for (int i = 1; i <= SIZE; i++)
            {
                possibleNumbers.Add(i);
            }

            for (int i = 0; i < SIZE; i++)
            {
                possibleNumbers.Remove(grid[row, i]);
                possibleNumbers.Remove(grid[i, col]);
            }

            int blockRowIndex = row / BLOCK_HEIGHT;
            int blockColIndex = col / BLOCK_WIDTH;

            for (int i = 0; i < BLOCK_HEIGHT; i++)
            {
                int cellRowIndex = BLOCK_HEIGHT * blockRowIndex + i;
                for (int j = 0; j < BLOCK_WIDTH; j++)
                {
                    int cellColIndex = BLOCK_WIDTH * blockColIndex + j;
                    possibleNumbers.Remove(grid[cellRowIndex, cellColIndex]);
                }
            }

            return possibleNumbers;
        }
    }
}
