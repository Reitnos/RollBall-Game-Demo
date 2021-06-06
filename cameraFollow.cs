using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private GameObject ball;
    private Vector3 targetPosition;
    public float smoothSpeed = 10f;
    public Vector3 offsetZplus = new Vector3(0f,7f,-7f);
    public Vector3 offsetZminus = new Vector3(0f, 7f, 7f);
    public Vector3 offsetXplus = new Vector3(-7f, 7f, 0f);
    public Vector3 offsetXminus = new Vector3(7f, 7f, 0f);

    private rollandMove ballFollow;
    

    

  
    private void LateUpdate()
    {
        ball = GameObject.FindGameObjectWithTag("player") ; // reaching the ball's position values.


        if (ball) // true if there is a ball in the scene, namely the ball hasn't yet hit any obstacle.
        {

            ballFollow = ball.GetComponent<rollandMove>();
       
      
            // applying the necessary offset depending on the balls current movement.

            if (ballFollow.zplus)
            {
                targetPosition = ball.GetComponent<Transform>().position + offsetZplus;
            }
            else if (ballFollow.zminus)
            {
                targetPosition = ball.GetComponent<Transform>().position + offsetZminus;

            }
            else if (ballFollow.xplus)
            {
                targetPosition = ball.GetComponent<Transform>().position + offsetXplus;

            }
            else if (ballFollow.xminus)
            {
                targetPosition = ball.GetComponent<Transform>().position + offsetXminus;

            }


            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime); 
            transform.position = smoothPosition;
        }

      
       
    }
}
