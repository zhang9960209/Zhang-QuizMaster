using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] QSOs Questions;
    [SerializeField] TextMeshProUGUI qText;
    
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
        NextQuestion();
        //DisplayQuestion();
        //DefaultButtonSprite();
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
        if (intIndex == Questions.GetCorrectAnsIndex())
        {
            qText.text = "Correct!";
            buttonImage = ansButtons[intIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnsSprite;
        }

        else
        {
            intCorrectAnsIndex = Questions.GetCorrectAnsIndex();
            string strCorrectAns = Questions.GetAnswer(intCorrectAnsIndex);
            qText.text = "Woops! The correct answer is: " + strCorrectAns;
            buttonImage = ansButtons[intCorrectAnsIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnsSprite;

        }
    }
    void NextQuestion()
    { 
        ButtonState(true);
        DefaultButtonSprite();
        DisplayQuestion();
    }
    
    void DisplayQuestion()
    {
        qText.text = Questions.GetQuestion();

        for (int i = 0; i < ansButtons.Length; i++)
        {
            TextMeshProUGUI bText = ansButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            bText.text = Questions.GetAnswer(i);

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



