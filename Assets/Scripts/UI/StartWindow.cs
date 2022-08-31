using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartWindow : UIController
    {
        [SerializeField] private Button _button;
        [SerializeField] private CanvasGroup _canvas;
        [SerializeField] private TextMeshProUGUI _text;
        
        public void Init()
        {
            _button.onClick.AddListener(Hide);
        }

        public void Hide()
        {
            _canvas.alpha = 0;
            _canvas.interactable = false;
            _canvas.blocksRaycasts = false;
        }

        public void Show(string text)
        {
            _canvas.alpha = 1;
            _canvas.interactable = true;
            _canvas.blocksRaycasts = true;
            _text.text = text;
        }

    }
}
