using System;
using UnityEngine;

namespace antoinegleisberg.SudokuGame.GameplayUI
{
    internal class NumberButton : MonoBehaviour
    {
        public event Action<NumberButton> OnButtonPressed;

        public void ButtonPressed()
        {
            OnButtonPressed?.Invoke(this);
        }
    }
}
