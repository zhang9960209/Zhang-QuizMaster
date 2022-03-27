using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] QSOs Questions;
    [SerializeField] TextMeshProUGUI qText;
    [SerializeField] GameObject[] ansButtons;

    int intCorrectAnsIndex;
    [SerializeField] Sprite defaultAnsSprite;
    [SerializeField] Sprite correctAnsSprite;

    void Start()
    {
        qText.text = Questions.GetQuestion();

        for (int i = 0; i < ansButtons.Length; i++)
        {
            TextMeshProUGUI bText = ansButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            bText.text = Questions.GetAnswer(i);

        }
    }

    public void OnAnsSelected(int intIndex)
    {
        Debug.Log("test");
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
            qText.text = "Woops! The correct answer is \n" + strCorrectAns;
            buttonImage = ansButtons[intCorrectAnsIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnsSprite;

        }
            
    }
}
