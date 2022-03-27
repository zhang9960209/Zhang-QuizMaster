using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuizQuestion", fileName = "New Question")]
public class QSOs : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string Question = "Enter the Question text here";

    public string GetQuestion()
    { 
        return Question;
    }
}
