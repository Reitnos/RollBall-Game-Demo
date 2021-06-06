using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectLeft: MonoBehaviour
{
   
    bool left = false; //  becomes true when the object is moved left and the next move will be right.
    void Start()
    {
        left = true;
        StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x -3f, transform.position.y, transform.position.z), 1f));
      

    }

 
    // periodic movement for an obstacle in x direction.   
    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
        if (left)
        {
            left = false;
            StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z), 1f));
        }
        else
        {
            left = true;
            StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x -3f, transform.position.y, transform.position.z), 1f));
        }
    }
}
