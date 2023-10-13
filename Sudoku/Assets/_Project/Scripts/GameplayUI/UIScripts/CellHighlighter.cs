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

            List<Cell> HighlightSameNumber()
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

            List<Cell> HightlightRowColBlock()
            {
                int BLOCK_WIDTH = sudoku.BlockWidth;
                int BLOCK_HEIGHT = sudoku.BlockHeight;

                Vector2Int coords = _sudokuManager.CellCoordinates(selectedCell);
                int blockX = coords.x / BLOCK_WIDTH;
                int blockY = coords.y / BLOCK_HEIGHT;

                List<Cell> cellsToHighlight = new List<Cell>();

                for (int i = 0; i < SIZE; i++)
                {
                    Cell cellToHightlight = _sudokuManager.CellAt(i, coords.y);
                    cellsToHighlight.Add(cellToHightlight);

                    cellToHightlight = _sudokuManager.CellAt(coords.x, i);
                    cellsToHighlight.Add(cellToHightlight);

                    cellToHightlight = _sudokuManager.CellAt(BLOCK_WIDTH * blockX + i / BLOCK_WIDTH, BLOCK_HEIGHT * blockY + i % BLOCK_HEIGHT);
                    cellsToHighlight.Add(cellToHightlight);
                }

                return cellsToHighlight;
            }

            Vector2Int coords = _sudokuManager.CellCoordinates(selectedCell);
            if (sudoku.Grid[coords.x, coords.y] == 0)
            {
                return HightlightRowColBlock();
            }
            else
            {
                return HighlightSameNumber();
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
