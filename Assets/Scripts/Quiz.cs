using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] List<QSOs> lsQuestions = new List<QSOs>();
    [SerializeField] TextMeshProUGUI qText;
    QSOs currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] ansButtons;
    int intCorrectAnsIndex;
    
    [Header("Button Sprite")]
    [SerializeField] Sprite defaultAnsSprite;
    [SerializeField] Sprite correctAnsSprite;

    [Header("Timer")]
    [SerializeField] Image timerImg;
    Timer timer;
    bool blEarlyAnswered;
    

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        
    }

    void Update()
    {
        timerImg.fillAmount = timer.flFillFraction;
        if (timer.blLoadNext)
        {
            blEarlyAnswered = false;
            NextQuestion();
            timer.blLoadNext = false;
        }

        else if (!blEarlyAnswered && !timer.blIsAnswering)
        {
            DisplayAns(-1);
            ButtonState(false);
        }
    }
    public void OnAnsSelected(int intIndex)
    {
        blEarlyAnswered = true;
        DisplayAns(intIndex);
        ButtonState(false);
        timer.CancelTimer();
    }

    void DisplayAns(int intIndex)
    {
        Image buttonImage;
        if (intIndex == currentQuestion.GetCorrectAnsIndex())
        {
            qText.text = "Correct!";
            buttonImage = ansButtons[intIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnsSprite;
        }

        else
        {
            intCorrectAnsIndex = currentQuestion.GetCorrectAnsIndex();
            string strCorrectAns = currentQuestion.GetAnswer(intCorrectAnsIndex);
            qText.text = "Woops! The correct answer is: " + strCorrectAns;
            buttonImage = ansButtons[intCorrectAnsIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnsSprite;

        }
    }
    void NextQuestion()
    {
        if (lsQuestions.Count > 0) 
        {
            ButtonState(true);
            DefaultButtonSprite();
            GetRandomQuestion();
            DisplayQuestion();
        }
       
       
    }

    void GetRandomQuestion()
    {
        int intIndex = Random.Range(0, lsQuestions.Count);
        currentQuestion = lsQuestions[intIndex];
        if (lsQuestions.Contains(currentQuestion))
        {
            lsQuestions.Remove(currentQuestion);
        }
        
    }
    void DisplayQuestion()
    {
        qText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < ansButtons.Length; i++)
        {
            TextMeshProUGUI bText = ansButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            bText.text = currentQuestion.GetAnswer(i);

        }
    }

    void ButtonState(bool blState)
    {
        for (int i = 0; i < ansButtons.Length; i++)
        { 
            Button button = ansButtons[i].GetComponent<Button>();
            button.interactable = blState;
        }
    }

    void DefaultButtonSprite()
    {
        for (int i = 0; i < ansButtons.Length; i++)
        { 
            Image buttonImage = ansButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnsSprite;
        }
    }
}



