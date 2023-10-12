using TMPro;
using UnityEngine;

namespace antoinegleisberg.SudokuGame
{
    public class NumberBar : MonoBehaviour
    {
        private NumberButton[] _numberButtons;
        private TextMeshProUGUI[] _numberTexts;

        private void Awake()
        {
            _numberButtons = new NumberButton[9];
            _numberTexts = new TextMeshProUGUI[9];

            Transform t = transform;
            for (int i = 0; i < t.childCount; i++)
            {
                Transform child = t.GetChild(i);
                _numberButtons[i] = child.GetComponent<NumberButton>();
                _numberTexts[i] = child.GetComponent<TextMeshProUGUI>();
                _numberTexts[i].text = $"{i + 1}";
            }
        }

        private void Start()
        {
            for (int i = 0; i < _numberButtons.Length; i++)
            {
                _numberButtons[i].OnButtonPressed += NumberButtonClicked;
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _numberButtons.Length; i++)
            {
                _numberButtons[i].OnButtonPressed -= NumberButtonClicked;
            }
        }

        public void NumberButtonClicked(NumberButton button)
        {
            int number = 0;
            while (_numberButtons[number] != button)
            {
                number++;
            }
            EventSystem.Instance.NumberSelected(number + 1);
        }
    }
}
