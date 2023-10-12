using System;
using UnityEngine;

namespace antoinegleisberg.SudokuGame
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
