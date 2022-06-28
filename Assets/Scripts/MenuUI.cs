using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    //public MainManager manager;
    //MainManager manager = new MainManager();
    //public MainManager manager;

    private void Start() 
    { 
        MainManager.Instance.LoadScore();

       
        int score = MainManager.score;

        if (highScoreText != null) 
        {
            highScoreText.text = "High Score: " + score;
        }

        //highScoreText = new highScoreText();

    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }



}

