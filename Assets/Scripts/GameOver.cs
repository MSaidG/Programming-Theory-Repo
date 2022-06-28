using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject menu;
    //ENCAPSULATION
    public bool gameOver { get; private set; }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            gameOver = true;
            gameOverMenu.gameObject.SetActive(true);
            menu.gameObject.SetActive(false);

            Time.timeScale = 0;

            //MainManager manager = new MainManager();
            if (MainManager.Instance)
            {
                if (BasketBallCount.countBasketBall > MainManager.score) MainManager.Instance.SaveScore();
            }
        }
    }
}
