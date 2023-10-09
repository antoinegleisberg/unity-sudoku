using UnityEngine;
using antoinegleisberg.Sudoku.GridGenerator;
using System.Collections.Generic;


namespace antoinegleisberg.Sudoku
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SudokuGridUI _gridUI;
        [SerializeField] private Cell _selectedCell;
        [SerializeField] private List<Cell> _highlightedCells;

        private int[,] _currentGrid;
        private int[,] _currentSolution;

        private void Awake()
        {
            _selectedCell = null;
        }

        private void Start()
        {
            int[,] grid = GridUtilities.GeneratePuzzle(3);
            _currentGrid = grid;

            _currentSolution = new int[9, 9];
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    _currentSolution[row, col] = grid[row, col];
                }
            }

            GridUtilities.SolveGrid(_currentSolution);

            _gridUI.FillGrid(grid);
        }

        private void OnEnable()
        {
            EventSystem.Instance.OnCellClicked += OnCellClicked;
            EventSystem.Instance.OnNumberSelected += OnNumberSelected;
        }

        private void OnDisable()
        {
            EventSystem.Instance.OnCellClicked -= OnCellClicked;
            EventSystem.Instance.OnNumberSelected -= OnNumberSelected;
        }

        private void OnCellClicked(Cell cell)
        {
            if (_selectedCell == cell)
            {
                _selectedCell.Unselect();
                _selectedCell = null;
                UnhighlightCells();
            }
            else
            {
                _selectedCell?.Unselect();
                _selectedCell = cell;
                UnhighlightCells();
                HighlightCells();
                _selectedCell.Select();
            }
        }

        private void UnhighlightCells()
        {
            foreach (Cell cell in _highlightedCells)
            {
                cell.Unhighlight();
            }
        }

        private void HighlightCells()
        {
            void HighlightSameNumber()
            {
                Vector2Int coords = _gridUI.CellCoordinates[_selectedCell];
                int selectedNumber = _currentGrid[coords.x, coords.y];

                for (int i = 0; i < 9; i++) {
                    for (int j = 0; j < 9; j++)
                    {
                        if (_currentGrid[i, j] == selectedNumber)
                        {
                            Cell cellToHighlight = _gridUI.CellAt(i, j);
                            cellToHighlight.Highlight();
                            _highlightedCells.Add(cellToHighlight);
                        }
                    }
                }
            }

            void HightlightRowColBlock()
            {
                Vector2Int coords = _gridUI.CellCoordinates[_selectedCell];
                int blockX = coords.x / 3;
                int blockY = coords.y / 3;

                for (int i = 0; i < 9; i++)
                {
                    Cell cellToHightlight = _gridUI.CellAt(i, coords.y);
                    cellToHightlight.Highlight();
                    _highlightedCells.Add(cellToHightlight);

                    cellToHightlight = _gridUI.CellAt(coords.x, i);
                    cellToHightlight.Highlight();
                    _highlightedCells.Add(cellToHightlight);

                    cellToHightlight = _gridUI.CellAt(3 * blockX + i / 3, 3 * blockY + i % 3);
                    cellToHightlight.Highlight();
                    _highlightedCells.Add(cellToHightlight);
                }
            }

            Vector2Int coords = _gridUI.CellCoordinates[_selectedCell];
            if (_currentGrid[coords.x, coords.y] == 0)
            {
                HightlightRowColBlock();
            }
            else
            {
                HighlightSameNumber();
            }
        }

        private void OnNumberSelected(int number)
        {
            Vector2Int coords = _gridUI.CellCoordinates[_selectedCell];

            if (_currentSolution[coords.x, coords.y] == number)
            {
                _currentGrid[coords.x, coords.y] = number;
                _gridUI.FillGrid(_currentGrid);
            }
            else
            {
                Debug.Log("Not the right number !!");
            }
        }
    }
}
