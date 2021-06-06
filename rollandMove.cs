using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollandMove : MonoBehaviour
{
    //rotation control booleans
    public bool zplus = true;
    public bool zminus = false;
    public bool xplus = false;
    public bool xminus = false;

    public float rollingSpeed = 30f;
    public float rotationSpeed = 400f;

    // rotation and roll vectors in x and z axis.
    Vector3 rotateVectorZplus;
    Vector3 rollVectorZplus;

    Vector3 rotateVectorZminus;
    Vector3 rollVectorZminus;

    Vector3 rotateVectorXplus;
    Vector3 rollVectorXplus;

    Vector3 rotateVectorXminus;
    Vector3 rollVectorXminus;
    // Start is called before the first frame update
    void Start()
    {
        
        rotateVectorZplus = new Vector3(rotationSpeed, 0f, 0f);
        rollVectorZplus = new Vector3(0f, 0f, rollingSpeed);
        rotateVectorZminus = new Vector3(-rotationSpeed, 0f, 0f);
        rollVectorZminus = new Vector3(0f, 0f, -rollingSpeed);
        rotateVectorXplus = new Vector3(0f, 0f, -rotationSpeed);
        rollVectorXplus = new Vector3(rollingSpeed, 0f, 0f);
        rotateVectorXminus = new Vector3(0f, 0f, rotationSpeed);
        rollVectorXminus = new Vector3(-rollingSpeed, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (zplus)
        {
            if(transform.rotation.y != 0 || transform.rotation.z != 0) // constantly checking the unexpected rotations in different axis.
            {
                transform.Rotate(new Vector3(rotateVectorZplus.x, 0, 0)*Time.deltaTime);
            }
            else
            {
                 transform.Rotate(rotateVectorZplus * Time.deltaTime); // rotates the ball at constant angular speed in x+ direction.

            }
            transform.position += rollVectorZplus * Time.deltaTime; // increases the z+ axis position at constant speed.
        }
        else if (zminus)
        {
            if (transform.rotation.y != 0 || transform.rotation.z != 0) // constantly checking the unexpected rotations in different axis.
            {
                transform.Rotate(new Vector3(rotateVectorZminus.x, 0, 0) * Time.deltaTime);

            }
            else
            {
            transform.Rotate(rotateVectorZminus * Time.deltaTime); // rotates the ball at constant angular speed in x- direction.

            }
            transform.position += rollVectorZminus * Time.deltaTime; // increases the z- axis position at constant speed.
        }
        else if (xplus)
        {
            if (transform.rotation.x != 0 || transform.rotation.y != 0) // constantly checking the unexpected rotations in different axis.
            {
                transform.Rotate(new Vector3(0, 0, rotateVectorXplus.z) * Time.deltaTime);

            }
            else
            {
            transform.Rotate(rotateVectorXplus * Time.deltaTime); // rotates the ball at constant angular speed in z- direction.

            }
            transform.position += rollVectorXplus * Time.deltaTime; // increases the x+ axis position at constant speed.
        }
        else if (xminus)
        {
            if (transform.rotation.x != 0 || transform.rotation.y != 0) // constantly checking the unexpected rotations in different axis.
            {
                transform.Rotate(new Vector3(0, 0, rotateVectorXminus.z) * Time.deltaTime);

            }
            else
            {
            transform.Rotate(rotateVectorXminus * Time.deltaTime); // rotates the ball at constant angular speed in z+ direction.

            }
            transform.position += rollVectorXminus * Time.deltaTime; // increases the x- axis position at constant speed.
        }

    }
   
    
}
