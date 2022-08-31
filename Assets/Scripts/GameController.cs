using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private StartWindow _startWindow;

    private List<QuestionsConfig> _questions;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI answerTextA;
    public TextMeshProUGUI answerTextB;
    public TextMeshProUGUI answerTextC;
    public TextMeshProUGUI answerTextD;
    public Button answerA;
    public Button answerB;
    public Button answerC;
    public Button answerD;


    public QuestionsConfig currentQuestion;
    private void Start()
    {
        _startWindow.Init();
        LoadResources();
        answerA.onClick.AddListener(SetAnswerA);
        answerB.onClick.AddListener(SetAnswerB);
        answerC.onClick.AddListener(SetAnswerC);
        answerD.onClick.AddListener(SetAnswerD);

        GetRandomQuestion();
        InsertValue();
    }

    public void LoadResources()
    {
        _questions = new List<QuestionsConfig>();
        var resources = Resources.LoadAll<QuestionsConfig>("QuestionConfig");
        for (var i = 0; i < resources.Length; i++)
        {
            _questions.Add(resources[i]);
        }
    }
    public void GetRandomQuestion()
    {
        if (_questions.Count > 1)
        {
            currentQuestion = _questions[Random.Range(0, _questions.Count)];
        }
        else
        {
            _startWindow.Show("Ви відповіли на Всі запитання. \n Вітаємо з перемогою у вікторині!");
        }
    }

    public void RemoveQuestion()
    {
        _questions.Remove(currentQuestion);
    }
    public void InsertValue()
    {
        questionText.text = currentQuestion.question;
        answerTextA.text = currentQuestion.answerA;
        answerTextB.text = currentQuestion.answerB;
        answerTextC.text = currentQuestion.answerC;
        answerTextD.text = currentQuestion.answerD;
    }

    public void CheckAnswer(TextMeshProUGUI answerText)  //string
    {
        if (currentQuestion.correctAnswer == answerText.text)
        {
            RemoveQuestion();
            GetRandomQuestion();
            InsertValue();
        }
        else
        {
            _questions.Clear();
            LoadResources();
            _startWindow.Show("Нажаль Ви помилилися, \n спробуємо ще? \n Натисніть, будь-куди");
        }
    }
    public void SetAnswerA()
    {
        CheckAnswer(answerTextA);
    }
    public void SetAnswerB()
    {
        CheckAnswer(answerTextB);
    }
    public void SetAnswerC()
    {
        CheckAnswer(answerTextC);
    }
    public void SetAnswerD()
    {
        CheckAnswer(answerTextD);
    }

    
}

   