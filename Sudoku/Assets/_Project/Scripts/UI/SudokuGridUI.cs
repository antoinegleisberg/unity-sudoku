using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace antoinegleisberg.Sudoku
{
    public class SudokuGridUI : MonoBehaviour
    {
        private TextMeshProUGUI[,] _textGrid;
        private Cell[,] _grid;
        private Dictionary<Cell, Vector2Int> _cellCoordinates;

        public Dictionary<Cell, Vector2Int> CellCoordinates => _cellCoordinates;

        public Cell CellAt(int x, int y)
        {
            return _grid[x, y];
        }

        private void Awake()
        {
            _textGrid = new TextMeshProUGUI[9, 9];
            _grid = new Cell[9, 9];
            _cellCoordinates = new Dictionary<Cell, Vector2Int>();

            for (int blockCol = 0; blockCol < transform.childCount; blockCol++)
            {
                Transform column = transform.GetChild(blockCol);
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
                            _textGrid[cellX, cellY] = cell.GetComponentInChildren<TextMeshProUGUI>();
                            _grid[cellX, cellY] = cell.GetComponent<Cell>();
                            _cellCoordinates.Add(cell.GetComponent<Cell>(), new Vector2Int(cellX, cellY));
                        }
                    }
                }
            }
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
    }
}
