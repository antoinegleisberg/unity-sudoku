using TMPro;
using UnityEngine;

namespace antoinegleisberg.SudokuGame.GameplayUI
{
    public class ErrorCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _errorCounterText;
        private int _errorCount;

        private void Awake()
        {
            _errorCount = 0;
            UpdateDisplay();
        }

        public void IncreaseErrorCounter()
        {
            _errorCount++;
            UpdateDisplay();
        }

        public void ResetErrors()
        {
            _errorCount = 0;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (_errorCount > 0)
            {
                _errorCounterText.text = $"Errors: {_errorCount}";
            }
            else
            {
                _errorCounterText.text = "";
            }
        }
    }
}
