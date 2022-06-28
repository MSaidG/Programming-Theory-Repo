using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovement : MonoBehaviour
{
    [SerializeField] private float boundZ = 9;
    [SerializeField] private float speedBox = 3;
    [SerializeField] private bool isRight = true;
    private int a = 1;
    private int b = 1;

    // Update is called once per frame
    private void Update()
    {
        MoveBetweenBounds();
    }

    private void MoveBetweenBounds()
    {


        if (isRight)
        {
            GoRight(b);
            if(transform.position.z >= boundZ)
            {
                a = Random.Range(1, 4);
                isRight = false;
            }
        }

        if (!isRight)
        {
            GoLeft(a);
            if(transform.position.z <= -boundZ)
            {
                b = Random.Range(1, 4);
                isRight = true;
            }
        }
    }

    private void GoRight(int x)
    {
        transform.Translate(0, 0, Time.deltaTime * speedBox * x);
    }

    private void GoLeft(int x)
    {
        transform.Translate(0, 0, -(Time.deltaTime * speedBox * x));
    }
}
