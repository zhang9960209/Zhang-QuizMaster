using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    FirstScene firstScene;
    Quiz quiz;
    FinalScene finalScene;

    void Awake()
    {
        firstScene = FindObjectOfType<FirstScene>();
        quiz = FindObjectOfType<Quiz>();
        finalScene = FindObjectOfType<FinalScene>();
    }

    void Start()
    {
        
        quiz.gameObject.SetActive(true);
        finalScene.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if (quiz.blIsComplete == true)
        { 
            quiz.gameObject.SetActive(false);
            finalScene.gameObject.SetActive(true);
            finalScene.ShowFinalTxt(); 
        }
    }

    public void RePlay(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
