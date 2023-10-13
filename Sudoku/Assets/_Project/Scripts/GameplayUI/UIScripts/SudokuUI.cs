using UnityEngine;

namespace antoinegleisberg.SudokuGame.GameplayUI
{
    internal class SudokuUI : MonoBehaviour
    {
        [SerializeField] private SudokuManager _sudokuManager;

        private void Awake()
        {
            _sudokuManager = FindObjectOfType<SudokuManager>();
        }

        public void FillGrid(int[,] grid)
        {
            int SIZE = grid.GetLength(0);

            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col ++)
                {
                    if (grid[row, col] == 0)
                    {
                        _sudokuManager.TextGrid[row, col].text = " ";
                        continue;
                    }
                    _sudokuManager.TextGrid[row, col].text = grid[row, col].ToString();
                }
            }
        }
    }
}
