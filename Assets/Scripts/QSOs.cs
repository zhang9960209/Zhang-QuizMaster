using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuizQuestion", fileName = "New Question")]
public class QSOs : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string Question = "Enter the Question text here";
    [SerializeField] string[] strAnswers = new string[4];
    [SerializeField] int correctAnsIndex; 
    public string GetQuestion()
    { 
        return Question;
    }

    public int GetCorrectAnsIndex()
    { 
        return correctAnsIndex;
    }

    public string GetAnswer(int intIndex)
    { 
        return strAnswers[intIndex]; 
    }
}
