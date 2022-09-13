using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MessageScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvas;
        [SerializeField] private Button _button;
        public event Action onButtonClick;

        public void Init()
        {
            _button.onClick.AddListener(ButtonClick);
        }
        public void Hide()
        {
            _canvas.alpha = 0;
            _canvas.interactable = false;
            _canvas.blocksRaycasts = false;
        }

        private void ButtonClick()
        {
            onButtonClick?.Invoke();
        }
        public void Show()
        {
            _canvas.alpha = 1;
            _canvas.interactable = true;
            _canvas.blocksRaycasts = true;
        }
    }
}
