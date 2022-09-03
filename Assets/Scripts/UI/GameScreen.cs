using UnityEngine;

namespace UI
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvas;
        [SerializeField] private Timer _timer;
        
        public void Hide()
        {
            _timer.isTimerGo = true;
            _canvas.alpha = 0;
            _canvas.interactable = false;
            _canvas.blocksRaycasts = false;
        }

        public void Show()
        {
            _timer.isTimerGo = false;
            _canvas.alpha = 1;
            _canvas.interactable = true;
            _canvas.blocksRaycasts = true;
        }
        
    }
}
