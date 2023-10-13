using TMPro;
using UnityEngine;

namespace antoinegleisberg.SudokuGame.GameplayUI
{
    internal class NumberBar : MonoBehaviour
    {
        [SerializeField] private Transform _numberButtonPrefab;

        private NumberButton[] _numberButtons;
        private TextMeshProUGUI[] _numberTexts;

        private void OnEnable()
        {
            SetButtonEventsSubscribtion(true);
        }

        private void OnDisable()
        {
            SetButtonEventsSubscribtion(false);
        }

        public void Init(int size)
        {
            _numberButtons = new NumberButton[size];
            _numberTexts = new TextMeshProUGUI[size];

            Transform t = transform;
            for (int i = 0; i < size; i++)
            {
                Transform child = Instantiate(_numberButtonPrefab, t);
                _numberButtons[i] = child.GetComponent<NumberButton>();
                _numberTexts[i] = child.GetComponent<TextMeshProUGUI>();
                _numberTexts[i].text = $"{i + 1}";
            }

            SetButtonEventsSubscribtion(true);
        }

        private void SetButtonEventsSubscribtion(bool value)
        {
            if (_numberButtons == null)
            {
                return;
            }

            for (int i = 0; i < _numberButtons.Length; i++)
            {
                if (value)
                {
                    _numberButtons[i].OnButtonPressed += NumberButtonClicked;
                }
                else
                {
                    _numberButtons[i].OnButtonPressed -= NumberButtonClicked;
                }
            }
        }

        private void NumberButtonClicked(NumberButton button)
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
