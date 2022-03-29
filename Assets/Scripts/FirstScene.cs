using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI beginTxt;

    public void ShowBeginTxt()
    {
        beginTxt.text = "Welcome to QUIZ-I-COOL\nClick Start to begin the quiz!";   
    }
}