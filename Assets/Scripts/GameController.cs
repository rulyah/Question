using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{

    private List<QuestionsConfig> _questions;

    [SerializeField] private TextMeshProUGUI _questionText;
    [SerializeField] private AnswerButton _answerA;
    [SerializeField] private AnswerButton _answerB;
    [SerializeField] private AnswerButton _answerC;
    [SerializeField] private AnswerButton _answerD;
    [SerializeField] private ClickableGameScreen _startWindow;
    [SerializeField] private ClickableGameScreen _wrongAnswerWindow;
    [SerializeField] private ClickableGameScreen _timerLossWindow;
    [SerializeField] private ClickableGameScreen _victoryWindow;
    [SerializeField] private GameScreen _blockClickPanel;
    [SerializeField] private Timer _timer;

    private QuestionsConfig _currentQuestion;
    private void Start()
    {
        _startWindow.Init();
        _startWindow.Show();
        _wrongAnswerWindow.Init();
        _timerLossWindow.Init();
        _victoryWindow.Init();
        LoadResources();
        _answerA.button.onClick.AddListener(SetAnswerA);
        _answerB.button.onClick.AddListener(SetAnswerB);
        _answerC.button.onClick.AddListener(SetAnswerC);
        _answerD.button.onClick.AddListener(SetAnswerD);
        _currentQuestion = GetRandomQuestion();
        InsertValue(_currentQuestion);
    }

    private void LoadResources()
    {
        _questions = new List<QuestionsConfig>();
        var resources = Resources.LoadAll<QuestionsConfig>("QuestionConfig");
        for (var i = 0; i < resources.Length; i++)
        {
            _questions.Add(resources[i]);
        }
    }
    private QuestionsConfig GetRandomQuestion()
    {
        if (_questions.Count == 0) return null;
        _currentQuestion = _questions[Random.Range(0, _questions.Count)];
        return _currentQuestion;
    }

    private void RemoveQuestion()
    {
        _questions.Remove(_currentQuestion);
    }
    private void InsertValue(QuestionsConfig config)
    {
        _questionText.text = config.question;
        _answerA.message.text = config.answerA;
        _answerA.isCorrectAnswer = config.isAnswerACorrect;
        _answerB.message.text = config.answerB;
        _answerB.isCorrectAnswer = config.isAnswerBCorrect;
        _answerC.message.text = config.answerC;
        _answerC.isCorrectAnswer = config.isAnswerCCorrect;
        _answerD.message.text = config.answerD;
        _answerD.isCorrectAnswer = config.isAnswerDCorrect;

    }

    private void CheckAnswer(AnswerButton button)
    {
        StartCoroutine(button.ChangeColor((() =>
        {
            if (button.isCorrectAnswer)
            {
                RemoveQuestion();
                GetRandomQuestion();
                InsertValue(_currentQuestion);
                _blockClickPanel.Hide();
                _timer.Refresh();
                button.ResetColor();
            }
            else
            {
                _questions.Clear();
                LoadResources();
                GetRandomQuestion();
                InsertValue(_currentQuestion);
                _blockClickPanel.Hide();
                _wrongAnswerWindow.Show();
                _timer.Refresh();
                button.ResetColor();
            }
        })));
    }
    private void SetAnswerA()
    {
        CheckAnswer(_answerA);
    }
    private void SetAnswerB()
    {
        CheckAnswer(_answerB);
    }
    private void SetAnswerC()
    {
        CheckAnswer(_answerC);
    }
    private void SetAnswerD()
    {
        CheckAnswer(_answerD);
    }
    private void Update()
    {
        _timer.TickTimer();
        
        if (_timer.time <= 0)
        {
            _timerLossWindow.Show();
            _timer.Refresh();
            InsertValue(GetRandomQuestion());
        }
        if (_currentQuestion == null)
        {
            _victoryWindow.Show();
        }
    }
}

   