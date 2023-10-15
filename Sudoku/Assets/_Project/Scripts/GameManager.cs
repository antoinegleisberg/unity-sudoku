using UnityEngine;
using antoinegleisberg.SudokuGame.SudokuGrid;
using antoinegleisberg.SudokuGame.GameplayUI;


namespace antoinegleisberg.SudokuGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SudokuManager _sudokuManager;
        [SerializeField] private MainMenu _mainMenu;

        [SerializeField] private Transform _sudokuPanel;
        [SerializeField] private Transform _mainMenuPanel;

        private void Start()
        {
            _mainMenu.OnPlayButtonClicked += StartGame;
        }

        private void OnDestroy()
        {
            _mainMenu.OnPlayButtonClicked -= StartGame;
        }

        private void StartGame(GameSettings gameSettings)
        {
            Sudoku sudoku = new Sudoku(gameSettings.sudokuSize, gameSettings.blockWidth, gameSettings.difficulty);
            _sudokuPanel.gameObject.SetActive(true);
            _mainMenuPanel.gameObject.SetActive(false);
            _sudokuManager.SetCurrentSudoku(sudoku);
        }
    }
}
