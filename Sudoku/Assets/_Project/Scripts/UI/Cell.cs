using UnityEngine;
using UnityEngine.UI;

namespace antoinegleisberg.SudokuGame
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Color _selectedColor;
        [SerializeField] private Color _unselectedColor;
        [SerializeField] private Color _highlightedColor;

        [SerializeField] private Image _image;

        public void OnClicked()
        {
            EventSystem.Instance.CellClicked(this);
        }

        public void Select()
        {
            _image.color = _selectedColor;
        }

        public void Unselect()
        {
            _image.color = _unselectedColor;
        }

        public void Highlight()
        {
            _image.color = _highlightedColor;
        }

        public void Unhighlight()
        {
            _image.color = _unselectedColor;
        }
    }
}
