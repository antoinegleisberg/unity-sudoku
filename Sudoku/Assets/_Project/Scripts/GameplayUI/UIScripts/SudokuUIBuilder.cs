using UnityEngine;


namespace antoinegleisberg.SudokuGame.GameplayUI
{
    internal class SudokuUIBuilder : MonoBehaviour
    {
        [SerializeField] private Transform _sudokuUIContainer;
        [SerializeField] private Transform _cellPrefab;
        [SerializeField] private Transform _blockColumnPrefab;
        [SerializeField] private Transform _blockPrefab;
        [SerializeField] private Transform _columnPrefab;
        [SerializeField] private Transform _gridPrefab;

        public Cell[,] BuildSudokuUI(int gridSize, int blockWidth)
        {
            return BuildSudokuGrid(gridSize, blockWidth);
        }

        private Cell[,] BuildSudokuGrid(int gridSize, int blockWidth)
        {
            Cell[,] cells = new Cell[gridSize, gridSize];

            int SIZE = gridSize; // 6
            int NROWS = blockWidth; // 3
            int NCOLS = SIZE / NROWS; // 2
            int N_BLOCK_ROWS = NCOLS; // 2
            int N_BLOCK_COLS = NROWS; // 3
            int BLOCK_HEIGHT = NCOLS; // 2
            int BLOCK_WIDTH = NROWS; // 3

            Transform grid = Instantiate(_gridPrefab, _sudokuUIContainer);
            
            for (int columnIndex = 0; columnIndex < NCOLS; columnIndex++)
            {
                Transform column = Instantiate(_columnPrefab, grid);

                for (int rowIndex = 0; rowIndex < NROWS; rowIndex++)
                {
                    Transform block = Instantiate(_blockPrefab, column);
                    Transform subgridContainer = block.GetChild(0);

                    for (int inblockColumnIndex = 0; inblockColumnIndex < N_BLOCK_COLS; inblockColumnIndex++)
                    {
                        Transform blockColumn = Instantiate(_blockColumnPrefab, subgridContainer);

                        for (int inblockRowIndex = 0; inblockRowIndex < N_BLOCK_ROWS; inblockRowIndex++)
                        {
                            Transform cell = Instantiate(_cellPrefab, blockColumn);

                            int row = rowIndex * BLOCK_HEIGHT + inblockRowIndex;
                            int col = columnIndex * BLOCK_WIDTH + inblockColumnIndex;

                            cells[row, col] = cell.GetComponent<Cell>();
                        }
                    }
                }
            }

            return cells;
        }
    }
}
