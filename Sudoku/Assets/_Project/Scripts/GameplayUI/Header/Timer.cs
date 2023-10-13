using TMPro;
using UnityEngine;
using antoinegleisberg.Time.Clock;


namespace antoinegleisberg.SudokuGame.GameplayUI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        private Clock _clock;


        private void Update()
        {
            if (_clock != null)
            {
                UpdateDisplay();
            }
        }

        public void StartTimer()
        {
            _clock= new Clock();
            UpdateDisplay();
        }

        public void StopTimer()
        {
            _clock = null;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (_clock == null)
            {
                return;
            }

            _timerText.text = _clock.GetFormattedTime();
        }
    }
}
