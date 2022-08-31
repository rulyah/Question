using UnityEngine;

[CreateAssetMenu(fileName = "QuestionConfig", menuName = "Question/Config")]
public class QuestionsConfig : ScriptableObject
{
    public string question, answerA, answerB, answerC, answerD;
    public string correctAnswer;
}
