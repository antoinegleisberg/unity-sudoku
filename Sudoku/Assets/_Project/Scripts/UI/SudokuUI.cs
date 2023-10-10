using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace antoinegleisberg.Sudoku
{
    public class SudokuUI : MonoBehaviour
    {
        private TextMeshProUGUI[,] _textGrid;
        [SerializeField] private SudokuManager _gridManager;

        [SerializeField] private List<Cell> _highlightedCells;

        private void Start()
        {
            _textGrid = _gridManager.TextGrid;
        }

        public void FillGrid(int[,] grid)
        {
            for (int row = 0; row < grid.GetLength(0) ; row++)
            {
                for (int col = 0; col < grid.GetLength(1); col ++)
                {
                    if (grid[row, col] == 0)
                    {
                        _textGrid[row, col].text = " ";
                        continue;
                    }
                    _textGrid[row, col].text = grid[row, col].ToString();
                }
            }
        }

        public void HighlightCells(List<Cell> cells)
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
    }
}
