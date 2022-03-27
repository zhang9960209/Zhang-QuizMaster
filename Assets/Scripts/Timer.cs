using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float flTimeToAnswer = 20f;
    [SerializeField] float flTimeToReview = 10f;

    bool blIsAnswering;
    float flTimerValue;
    public bool blLoadNext;
    public float flFillFraction;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    { 
        flTimerValue = 0;
    }
    void UpdateTimer()
    { 
        flTimerValue -= Time.deltaTime;
        if (blIsAnswering)
        {
            if (flTimerValue > 0)
            {
                flFillFraction = flTimerValue / flTimeToAnswer;
            }
            else
            { 
                blIsAnswering = false;
                flTimerValue = flTimeToReview;
            }
        }
        else
        {
            if (flTimerValue > 0)
            {
                flFillFraction = flTimerValue / flTimeToReview;
            }
            else
            {
                blIsAnswering = true;
                flTimerValue = flTimeToAnswer;
                blLoadNext = true;
            }
        }
    }
}
