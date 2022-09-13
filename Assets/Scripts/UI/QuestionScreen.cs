using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class QuestionScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _questionText;
        private AnswerButton _currentAnswerButton;
        
        public List<AnswerButton> answerButtons = new List<AnswerButton>();

        public event Action<int> onAnswerClick;

        public void Init()
        {
            for (var i = 0; i < answerButtons.Count; i++)
            {
                answerButtons[i].Init();
                answerButtons[i].OnButtonClick += OnAnswerButtonClick;
            }
        }
        
        public void PlayConfirm(Action action)
        {
            _currentAnswerButton.PlayConfirmAnswer(action);
        }

        public void PlayCorrect(Action action)
        {
            _currentAnswerButton.PlayCorrectAnswer(action);
        }

        public void PlayWrong(Action action)
        {
            _currentAnswerButton.PlayWrongAnswer(action);
        }
        
        private void OnAnswerButtonClick(int buttonId)
        {
            _currentAnswerButton = FindButtonById(buttonId);
            onAnswerClick?.Invoke(buttonId);
        }

        private AnswerButton FindButtonById(int id)
        {
            return answerButtons.Find(n => n.buttonID == id);
        }
        
        
        public void InsertQuestionValue(QuestionsConfig questions)
        {
            _questionText.text = questions.question;
            answerButtons[0].message.text = questions.answerA;
            answerButtons[1].message.text = questions.answerB;
            answerButtons[2].message.text = questions.answerC;
            answerButtons[3].message.text = questions.answerD;
        }
    }
}