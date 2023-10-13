using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace antoinegleisberg.SudokuGame.GameplayUI
{
    internal class SudokuUIBuilder : MonoBehaviour
    {
        [SerializeField] private Transform _sudokuUIContainer;
        [SerializeField] private Transform _cellPrefab;
        [SerializeField] private Transform _blockColumnPrefab;
        [SerializeField] private Transform _blockPrefab;
        [SerializeField] private Transform _columnPrefab;
        [SerializeField] private Transform _gridPrefab;

        public Cell[,] BuildSudokuUI(int gridSize, int blockWidth)
        {
            return BuildSudokuGrid(gridSize, blockWidth);
        }

        private Cell[,] BuildSudokuGrid(int gridSize, int blockWidth)
        {
            Cell[,] cells = new Cell[gridSize, gridSize];

            int SIZE = gridSize;
            int NROWS = blockWidth;
            int NCOLS = SIZE / NROWS;
            int N_BLOCK_ROWS = NCOLS;
            int N_BLOCK_COLS = NROWS;
            int BLOCK_HEIGHT = NCOLS;
            int BLOCK_WIDTH = NROWS;

            Transform grid = Instantiate(_gridPrefab, _sudokuUIContainer);
            
            for (int i = 0; i < NCOLS; i++)
            {
                Transform column = Instantiate(_columnPrefab, grid);

                for (int j = 0; j < NROWS; j++)
                {
                    Transform block = Instantiate(_blockPrefab, column);
                    Transform subgridContainer = block.GetChild(0);

                    for (int block_i = 0; block_i < N_BLOCK_COLS; block_i++)
                    {
                        Transform blockColumn = Instantiate(_blockColumnPrefab, subgridContainer);

                        for (int block_j = 0; block_j < N_BLOCK_ROWS; block_j++)
                        {
                            Transform cell = Instantiate(_cellPrefab, blockColumn);

                            int row = j * BLOCK_HEIGHT + block_j;
                            int col = i * BLOCK_WIDTH + block_i;

                            cells[row, col] = cell.GetComponent<Cell>();
                        }
                    }
                }
            }

            return cells;
        }
    }
}
