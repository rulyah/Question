using UnityEngine;

[CreateAssetMenu(fileName = "QuestionConfig", menuName = "Question/Config")]
public class QuestionsConfig : ScriptableObject
{
    public string question;
    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;
    public int correctButtonId;
}
