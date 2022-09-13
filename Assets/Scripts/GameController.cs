using System.Collections.Generic;
using StateMachine;
using UI;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public List<QuestionsConfig> questions { get; set; }

    [SerializeField] private MessageScreen _startWindow;
    public MessageScreen startWindow => _startWindow;
    [SerializeField] private MessageScreen _wrongAnswerWindow;
    public MessageScreen wrongAnswerWindow => _wrongAnswerWindow;
    [SerializeField] private MessageScreen _timerLossWindow;
    public MessageScreen timerLossWindow => _timerLossWindow;
    [SerializeField] private MessageScreen _victoryWindow;
    public MessageScreen victoryWindow => _victoryWindow;
    [SerializeField] private Timer _timer;
    public Timer timer => _timer;
    [SerializeField] private QuestionScreen _questionScreen;
    public QuestionScreen questionScreen => _questionScreen;

    public QuestionsConfig currentQuestion { get; private set; }
    public GameStateMachine stateMachine { get; private set; }
    private void Start()
    {
        questions = new List<QuestionsConfig>();
        _startWindow.Init();
        _wrongAnswerWindow.Init();
        _timerLossWindow.Init();
        _victoryWindow.Init();
        stateMachine = new GameStateMachine(this);
        _questionScreen.Init();
    }

    public void GenerateRandomQuestion()
    {
        currentQuestion = questions.Count == 0 ? null : questions[Random.Range(0, questions.Count)];
    }
    private void Update()
    {
        stateMachine.Update();
    }
}