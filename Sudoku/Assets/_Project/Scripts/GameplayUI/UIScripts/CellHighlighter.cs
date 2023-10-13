using antoinegleisberg.SudokuGame.SudokuGrid;
using System.Collections.Generic;
using UnityEngine;

namespace antoinegleisberg.SudokuGame.GameplayUI
{
    internal class CellHighlighter : MonoBehaviour
    {
        [SerializeField] private SudokuManager _sudokuManager;
        private List<Cell> _highlightedCells;

        public void HighlightCells(Sudoku sudoku, Cell selectedCell)
        {
            List<Cell> cellsToHighlight = GetCellsToHighlight(sudoku, selectedCell);

            HighlightCells(cellsToHighlight);
        }
        
        public void UnhighlightCells()
        {
            if (_highlightedCells == null)
            {
                return;
            }

            foreach (Cell cell in _highlightedCells)
            {
                cell.Unhighlight();
            }
        }
        
        private List<Cell> GetCellsToHighlight(Sudoku sudoku, Cell selectedCell)
        {
            int SIZE = sudoku.Size;

            List<Cell> GetCellsWithSameNumber()
            {
                Vector2Int coords = _sudokuManager.CellCoordinates(selectedCell);
                int selectedNumber = sudoku.NumberAt(coords);

                List<Cell> cellsToHighlight = new List<Cell>();

                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        if (sudoku.Grid[i, j] == selectedNumber)
                        {
                            Cell cellToHighlight = _sudokuManager.CellAt(i, j);
                            cellsToHighlight.Add(cellToHighlight);
                        }
                    }
                }

                return cellsToHighlight;
            }

            List<Cell> GetCellsInRowColBlock()
            {
                int BLOCK_WIDTH = sudoku.BlockWidth;
                int BLOCK_HEIGHT = sudoku.BlockHeight;

                Vector2Int coords = _sudokuManager.CellCoordinates(selectedCell);
                int blockRowIndex = coords.x / BLOCK_HEIGHT;
                int blockColIndex = coords.y / BLOCK_WIDTH;

                List<Cell> cellsToHighlight = new List<Cell>();

                for (int i = 0; i < SIZE; i++)
                {
                    Cell cellToHightlight = _sudokuManager.CellAt(i, coords.y);
                    cellsToHighlight.Add(cellToHightlight);

                    cellToHightlight = _sudokuManager.CellAt(coords.x, i);
                    cellsToHighlight.Add(cellToHightlight);

                    int row = blockRowIndex * BLOCK_HEIGHT + i / BLOCK_WIDTH;
                    int col = blockColIndex * BLOCK_WIDTH + i % BLOCK_WIDTH;
                    cellToHightlight = _sudokuManager.CellAt(row, col);
                    cellsToHighlight.Add(cellToHightlight);
                }

                return cellsToHighlight;
            }

            Vector2Int coords = _sudokuManager.CellCoordinates(selectedCell);
            if (sudoku.Grid[coords.x, coords.y] == 0)
            {
                return GetCellsInRowColBlock();
            }
            else
            {
                return GetCellsWithSameNumber();
            }
        }
        
        private void HighlightCells(List<Cell> cells)
        {
            if (_highlightedCells == null)
            {
                _highlightedCells = new List<Cell>();
            }

            foreach (Cell cell in cells)
            {
                cell.Highlight();
                _highlightedCells.Add(cell);
            }
        }
    }
}
