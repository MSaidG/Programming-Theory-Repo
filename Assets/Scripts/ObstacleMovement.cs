using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : BasketMovement

    //INHERITANCE
    //POLYMORPHISM
{
    private readonly float speedObstacle = 2;
    private readonly float boundZ = 8;
    private bool isRightT = false;
    private int aA = 1;
    private int bB = 1;

    // Update is called once per frame
    void Update()
    {
        MoveBetweenBounds();
    }

    public override void MoveBetweenBounds()
    {


        if (isRightT)
        {
            GoRight(bB);
            if (transform.position.z >= boundZ)
            {
                aA = Random.Range(1, 3);
                isRightT = false;
            }
        }

        if (!isRightT)
        {
            GoLeft(aA);
            if (transform.position.z <= -boundZ)
            {
                bB = Random.Range(1, 3);
                isRightT = true;
            }
        }
    }

    public override void GoRight(int x)
    {
        transform.Translate(0, 0, Time.deltaTime * speedObstacle * x);
    }

    public override void GoLeft(int x)
    {
        transform.Translate(0, 0, -(Time.deltaTime * speedObstacle * x));
    }
}
