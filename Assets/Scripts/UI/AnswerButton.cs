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
        public Button button;
        public TextMeshProUGUI message;
        private Color32 _baseColor32;
        public bool isCorrectAnswer;

        public void ResetColor()
        {
            _image.color = _baseColor32;
        }

        public IEnumerator ChangeColor(Action action)
        {
            _baseColor32 = _image.color;
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
            _image.color = isCorrectAnswer ? 
                new Color32(0, 255, 0, 255) : new Color32(255, 0, 0, 255);
            yield return new WaitForSeconds(1.5f);
            action?.Invoke();
        } 
    }
    
}
