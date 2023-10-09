using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace antoinegleisberg.Sudoku
{
    public class EventSystem : MonoBehaviour
    {
        public static EventSystem Instance { get; private set; }

        public event Action<Cell> OnCellClicked;

        public event Action<int> OnNumberSelected;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void CellClicked(Cell cell)
        {
            OnCellClicked?.Invoke(cell);
        }

        public void NumberSelected(int number)
        {
            OnNumberSelected?.Invoke(number);
        }
    }
}
