using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSaw : MonoBehaviour
{
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(360f, 0f, 0f) * Time.deltaTime); // rotate the saws in x axis.
    }
}
