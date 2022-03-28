using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalTxt;
    Score scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<Score>();
    }

    public void ShowFinalTxt()
    {
        finalTxt.text = "Thanks for taking the quiz. \nYou scored " +
                        scoreKeeper.ScoreCalculator() + "% accuracy."; 
    }
}
