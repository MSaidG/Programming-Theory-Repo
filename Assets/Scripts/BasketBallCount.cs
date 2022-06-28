using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasketBallCount : MonoBehaviour
{
    public TextMeshProUGUI counterText;

    //ENCAPSULATION
    public static int countBasketBall{ get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        countBasketBall = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        countBasketBall += 1;
        counterText.text = "Score: " + countBasketBall;
    }
}
