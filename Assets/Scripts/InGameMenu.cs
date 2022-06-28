using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.GetActiveScene();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {

        Time.timeScale = 1;
    }

    public void ReturnToMenu()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1;

        //MainManager manager = new MainManager();
        if (MainManager.Instance)
        {
            if (BasketBallCount.countBasketBall > MainManager.score) MainManager.Instance.SaveScore();
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

}
