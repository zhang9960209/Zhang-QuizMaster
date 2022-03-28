using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int intCorrectAns = 0;
    int intQAnswered = 0;

    public int GetCorrectAns()
    { 
        return intCorrectAns;
    }

    public void IncrementCorrectAns()
    { 
        intCorrectAns++;
    }

    public int GetQAnswered()
    {
        return intQAnswered;
    }

    public void IncrementQAnswered()
    {
        intQAnswered++;
    }

    public int ScoreCalculator()
    { 
        return Mathf.RoundToInt(intCorrectAns / (float)intQAnswered * 100);
    }
}
