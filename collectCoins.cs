using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCoins : MonoBehaviour
{
    public int coinVal = 1;
  

    // I am using on trigger here because using onCollisionEnter uses the physics collisions and 
    // it manipulates the roll of the ball.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            staticCoinNumber.instance.increaseCoins(coinVal); // if the coin collided with ball, then increase our global coin count.
            Destroy(this.gameObject);
        }
    }
}
