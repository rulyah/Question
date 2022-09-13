using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AnswerButton : MonoBehaviour
    {
        
        
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        public TextMeshProUGUI message;
        private Color32 _baseColor32;
        public int buttonID;

        public event Action <int> OnButtonClick;
        public void Init()
        {
            _baseColor32 = _image.color;
            _button.onClick.AddListener(ButtonClick);
        }

        private void ButtonClick()
        {
            OnButtonClick?.Invoke(buttonID);
        }
        
        public void PlayConfirmAnswer(Action action)
        {
            StartCoroutine(ButtonBlinking(action));
        }

        public void PlayCorrectAnswer(Action action)
        {
            StartCoroutine(CorrectAnswer(action));
        }

        public void PlayWrongAnswer(Action action)
        {
            StartCoroutine(WrongAnswer(action));
        }
        
        
        private IEnumerator CorrectAnswer(Action action)
        {
            _image.color = new Color32(0, 255, 0, 255);
            yield return new WaitForSeconds(1.0f);
            action?.Invoke();
            _image.color = _baseColor32;
        }

        private IEnumerator WrongAnswer(Action action)
        {
            _image.color = new Color32(255, 0, 0, 255);
            yield return new WaitForSeconds(1.0f);
            action?.Invoke();
            _image.color = _baseColor32;
        }
        
        private IEnumerator ButtonBlinking(Action action)
        {
            _image.color = new Color32(97, 142, 195, 255);
            yield return new WaitForSeconds(1.0f);
            _image.color = _baseColor32;
            yield return new WaitForSeconds(0.5f);
            _image.color = new Color32(97, 142, 195, 255);
            yield return new WaitForSeconds(0.75f);
            _image.color = _baseColor32;
            yield return new WaitForSeconds(0.5f);
            _image.color = new Color32(97, 142, 195, 255);
            yield return new WaitForSeconds(0.5f);
            action?.Invoke();
        } 
    }
    
}
