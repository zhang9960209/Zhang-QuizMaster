using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] QSOs Questions;
    [SerializeField] TextMeshProUGUI qText;
    void Start()
    {
        qText.text = Questions.GetQuestion();
    }

}
