using UnityEngine;

[CreateAssetMenu(fileName = "QuestionConfig", menuName = "Question/Config")]
public class QuestionsConfig : ScriptableObject
{
    public string question;
    public string answerA;
    public bool isAnswerACorrect;
    public string answerB;
    public bool isAnswerBCorrect;
    public string answerC;
    public bool isAnswerCCorrect;
    public string answerD;
    public bool isAnswerDCorrect;
}
