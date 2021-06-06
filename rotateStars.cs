using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateStars : MonoBehaviour
{
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f, 360f, 0f) * Time.deltaTime); // rotate the stars in y axis.
    }
}
