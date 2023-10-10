using UnityEngine;
using antoinegleisberg.Sudoku.GridGenerator;


namespace antoinegleisberg.Sudoku
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SudokuUI _gridUI;
        [SerializeField] private SudokuManager _gridManager;

        [SerializeField] private int _gridSize;

        private void Start()
        {
            int[,] grid = GridUtilities.GeneratePuzzle(3, _gridSize);
            _gridManager.SetCurrentGrid(grid);
        }
    }
}
