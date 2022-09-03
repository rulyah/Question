using UnityEngine.UI;

namespace UI
{
    public class ClickableGameScreen : GameScreen
    {
        public Button _button;
        
        public void Init()
        {
            _button.onClick.AddListener(Hide);
        }
    }
}