using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticCoinNumber : MonoBehaviour
{
    public static staticCoinNumber instance;
    int score; // this is the current coin count.

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void increaseCoins(int coinVal) // the outside scripts that calling this function with parameter 1 will increase the score.
    {
        score += coinVal;
        
        
    }
    public int getScore()
    {
        return score; // returning the current score.
    }
}
