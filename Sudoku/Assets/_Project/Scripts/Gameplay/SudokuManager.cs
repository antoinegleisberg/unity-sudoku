using antoinegleisberg.SudokuGame.SudokuGrid;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace antoinegleisberg.SudokuGame
{
    public class SudokuManager : MonoBehaviour
    {
        [SerializeField] private SudokuUI _sudokuUI;

        private Cell[,] _grid;
        private Dictionary<Cell, Vector2Int> _cellCoordinates;
        private TextMeshProUGUI[,] _textGrid;

        private Cell _selectedCell;

        private Sudoku _currentSudoku;

        public TextMeshProUGUI[,] TextGrid => _textGrid;

        public Cell CellAt(int x, int y)
        {
            return _grid[x, y];
        }

        public Vector2Int CellCoordinates(Cell cell)
        {
            return _cellCoordinates[cell];
        }

        private void Awake()
        {
            _grid = new Cell[9, 9];
            _cellCoordinates = new Dictionary<Cell, Vector2Int>();
            _textGrid = new TextMeshProUGUI[9, 9];

            for (int blockCol = 0; blockCol < _sudokuUI.transform.childCount; blockCol++)
            {
                Transform column = _sudokuUI.transform.GetChild(blockCol);
                for (int blockRow = 0; blockRow < column.childCount; blockRow++)
                {
                    Transform block = column.GetChild(blockRow).GetChild(0);
                    for (int cellCol = 0; cellCol < block.childCount; cellCol++)
                    {
                        Transform cellColumn = block.GetChild(cellCol);
                        for (int cellRow = 0; cellRow < cellColumn.childCount; cellRow++)
                        {
                            Transform cell = cellColumn.GetChild(cellRow);
                            int cellX = 3 * blockRow + cellRow;
                            int cellY = 3 * blockCol + cellCol;
                            _grid[cellX, cellY] = cell.GetComponent<Cell>();
                            _cellCoordinates.Add(cell.GetComponent<Cell>(), new Vector2Int(cellX, cellY));
                            _textGrid[cellX, cellY] = cell.GetComponentInChildren<TextMeshProUGUI>();
                        }
                    }
                }
            }
        }

        private void Start()
        {
            EventSystem.Instance.OnCellClicked += OnCellClicked;
            EventSystem.Instance.OnNumberSelected += OnNumberSelected;
        }

        private void OnDestroy()
        {
            EventSystem.Instance.OnCellClicked -= OnCellClicked;
            EventSystem.Instance.OnNumberSelected -= OnNumberSelected;
        }

        public void SetCurrentSudoku(Sudoku sudoku)
        {
            _currentSudoku = sudoku;
            _sudokuUI.FillGrid(sudoku.Grid);
        }

        private void OnNumberSelected(int number)
        {
            Vector2Int coords = CellCoordinates(_selectedCell);

            if (_currentSudoku.IsCorrect(coords, number))
            {
                _currentSudoku.FillCell(coords);
                _sudokuUI.FillGrid(_currentSudoku.Grid);
            }
            else
            {
                Debug.Log("Not the right number !!");
            }
        }

        private void OnCellClicked(Cell cell)
        {
            if (_selectedCell == cell)
            {
                _selectedCell.Unselect();
                _selectedCell = null;
                _sudokuUI.UnhighlightCells();
            }
            else
            {
                _selectedCell?.Unselect();
                _selectedCell = cell;
                _sudokuUI.UnhighlightCells();
                HighlightCells();
                _selectedCell.Select();
            }
        }

        private void HighlightCells()
        {
            List<Cell> HighlightSameNumber()
            {
                Vector2Int coords = CellCoordinates(_selectedCell);
                int selectedNumber = _currentSudoku.NumberAt(coords);

                List<Cell> cellsToHighlight = new List<Cell>();

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (_currentSudoku.Grid[i, j] == selectedNumber)
                        {
                            Cell cellToHighlight = CellAt(i, j);
                            cellsToHighlight.Add(cellToHighlight);
                        }
                    }
                }

                return cellsToHighlight;
            }

            List<Cell> HightlightRowColBlock()
            {
                Vector2Int coords = CellCoordinates(_selectedCell);
                int blockX = coords.x / 3;
                int blockY = coords.y / 3;

                List<Cell> cellsToHighlight = new List<Cell>();

                for (int i = 0; i < 9; i++)
                {
                    Cell cellToHightlight = CellAt(i, coords.y);
                    cellsToHighlight.Add(cellToHightlight);

                    cellToHightlight = CellAt(coords.x, i);
                    cellsToHighlight.Add(cellToHightlight);

                    cellToHightlight = CellAt(3 * blockX + i / 3, 3 * blockY + i % 3);
                    cellsToHighlight.Add(cellToHightlight);
                }

                return cellsToHighlight;
            }

            Vector2Int coords = CellCoordinates(_selectedCell);
            List<Cell> cellsToHighlight;
            if (_currentSudoku.Grid[coords.x, coords.y] == 0)
            {
                cellsToHighlight = HightlightRowColBlock();
            }
            else
            {
                cellsToHighlight = HighlightSameNumber();
            }
            _sudokuUI.HighlightCells(cellsToHighlight);
        }
    }
}
