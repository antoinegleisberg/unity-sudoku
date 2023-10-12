using UnityEngine;
using antoinegleisberg.SudokuGame.SudokuGrid;


namespace antoinegleisberg.SudokuGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SudokuUI _gridUI;
        [SerializeField] private SudokuManager _gridManager;

        [SerializeField] private int _gridSize;

        private void Start()
        {
            Sudoku sudoku = new Sudoku(difficulty: 3);
            _gridManager.SetCurrentSudoku(sudoku);
        }
    }
}
