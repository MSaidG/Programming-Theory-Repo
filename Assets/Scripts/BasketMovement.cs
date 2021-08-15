using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovement : MonoBehaviour
{
    [SerializeField] private float boundZ = 10;
    [SerializeField] private float speedBox = 3;
    [SerializeField] private bool isRight = true;

    // Update is called once per frame
    private void Update()
    {
        MoveBetweenBounds();
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
        float a = Random.Range(1, 2);
        transform.Translate(0, 0, Time.deltaTime * speedBox);
    }

    private void GoLeft()
    {
        float a = Random.Range(1, 2);
        transform.Translate(0, 0, -(Time.deltaTime * speedBox));
    }
}
