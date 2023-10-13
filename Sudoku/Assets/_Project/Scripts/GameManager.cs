using UnityEngine;
using antoinegleisberg.SudokuGame.SudokuGrid;
using antoinegleisberg.SudokuGame.GameplayUI;


namespace antoinegleisberg.SudokuGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SudokuManager _sudokuManager;

        [SerializeField] private int _gridSize;
        [SerializeField] private int _blockWidth;

        private void Start()
        {
            Sudoku sudoku = new Sudoku(_gridSize, _blockWidth, 3);
            _sudokuManager.SetCurrentSudoku(sudoku);
        }
    }
}
