using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovement : MonoBehaviour
{
    private float boundZ = 10;
    private float speedBox = 3;
    private bool isRight = true;

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void MoveBetweenBounds()
    {
        if (isRight)
        {
            GoRight();
            if(transform.position.z >= boundZ)
            {
                isRight = false;
            }
        }

        if (!isRight)
        {
            GoLeft();
            if(transform.position.z <= -boundZ)
            {
                isRight = true;
            }
        }
    }

    private void GoRight()
    {
        float a = Random.Range(2, 10);
        transform.Translate(0, 0, a * Time.deltaTime);
    }

    private void GoLeft()
    {
        float a = Random.Range(2, 10);
        transform.Translate(0, 0, -(a * Time.deltaTime));
    }
}
