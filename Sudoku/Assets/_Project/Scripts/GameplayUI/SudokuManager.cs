using antoinegleisberg.SudokuGame.SudokuGrid;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace antoinegleisberg.SudokuGame.GameplayUI
{
    public class SudokuManager : MonoBehaviour
    {
        [SerializeField] private SudokuUIBuilder _sudokuUIBuilder;
        [SerializeField] private NumberBar _numberBar;
        [SerializeField] private CellHighlighter _cellHighlighter;
        private SudokuUI _sudokuUI;
        private Sudoku _currentSudoku;
        
        private Cell[,] _cells;
        private Dictionary<Cell, Vector2Int> _cellCoordinates;
        private TextMeshProUGUI[,] _textGrid;

        private Cell _selectedCell;

        public TextMeshProUGUI[,] TextGrid => _textGrid;

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

        public void SetCurrentSudoku(Sudoku sudoku)
        {
            _currentSudoku = sudoku;
            Cell[,] cells = _sudokuUIBuilder.BuildSudokuUI(sudoku.Size, sudoku.BlockWidth);
            Init(cells);
            _sudokuUI = FindObjectOfType<SudokuUI>();
            _sudokuUI.FillGrid(sudoku.Grid);
            _numberBar.Init(sudoku.Size);
        }

        internal Cell CellAt(int x, int y)
        {
            return _cells[x, y];
        }

        internal Vector2Int CellCoordinates(Cell cell)
        {
            return _cellCoordinates[cell];
        }
        
        private void Init(Cell[,] cells)
        {
            int SIZE = cells.GetLength(0);

            _cells = cells;
            _cellCoordinates = new Dictionary<Cell, Vector2Int>();
            _textGrid = new TextMeshProUGUI[SIZE, SIZE];

            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
                {
                    _cellCoordinates.Add(_cells[row, col], new Vector2Int(row, col));
                    _textGrid[row, col] = _cells[row, col].GetComponentInChildren<TextMeshProUGUI>();
                }
            }
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
                _cellHighlighter.UnhighlightCells();
            }
            else
            {
                _selectedCell?.Unselect();
                _selectedCell = cell;
                _cellHighlighter.UnhighlightCells();
                _cellHighlighter.HighlightCells(_currentSudoku, _selectedCell);
                _selectedCell.Select();
            }
        }
    }
}
