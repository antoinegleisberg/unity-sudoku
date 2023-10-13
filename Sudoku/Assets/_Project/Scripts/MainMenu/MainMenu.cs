using System;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.UI;

namespace antoinegleisberg.SudokuGame
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Slider _gridSizeSlider;
        [SerializeField] private Slider _blockSizeSlider;
        [SerializeField] private Slider _difficultySlider;

        public event Action<GameSettings> OnPlayButtonClicked;

        public void ClickPlayButton()
        {
            GameSettings gameSettings = new GameSettings()
            {
                sudokuSize = Mathf.RoundToInt(_gridSizeSlider.value),
                blockWidth = Mathf.RoundToInt(_blockSizeSlider.value),
                difficulty = Mathf.RoundToInt(_difficultySlider.value)
            };

            OnPlayButtonClicked.Invoke(gameSettings);
        }

        public void OnSliderValueChanged()
        {
            float blockHeight = _gridSizeSlider.value / _blockSizeSlider.value;
            while (Mathf.RoundToInt(blockHeight) - blockHeight > Mathf.Epsilon)
            {
                _gridSizeSlider.value += 1;
                blockHeight = _gridSizeSlider.value / _blockSizeSlider.value;
            }
        }
    }

    public struct GameSettings
    {
        public int sudokuSize;
        public int blockWidth;
        public int difficulty;
    }
}
