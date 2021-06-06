using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalMovementControl : MonoBehaviour
{
    public static globalMovementControl instance;
    int position = 0; // this variable will hold the position information of the ball. -1 if it is at the very left, +1 if at the very right.

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int readPosition()
    {
        return position;
    }
    public void resetPosition()
    {
        position = 0;
    }
    public void move(int moveDirection) // the outside scripts that calling this function with parameter 1 will increase the score.
    {
        position += moveDirection;
        

    }
}
