using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace antoinegleisberg.Sudoku
{
    public class NumberButton : MonoBehaviour
    {
        public event Action<NumberButton> OnButtonPressed;

        public void ButtonPressed()
        {
            OnButtonPressed?.Invoke(this);
        }
    }
}
