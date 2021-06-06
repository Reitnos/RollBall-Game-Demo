using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWallRight : MonoBehaviour
{
   
    bool right = false;  // becomes true when the object is moved right and the next move will be left.
    void Start()
    {
        right = true;
        StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x + 7f, transform.position.y, transform.position.z), 1f));


    }

    // periodic movement for an obstacle in x direction first right then left with larger movement.

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
        if (right)
        {
            right = false;
            StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x - 7f, transform.position.y, transform.position.z), 1f));
        }
        else
        {
            right = true;
            StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x + 7f, transform.position.y, transform.position.z), 1f));
        }
    }
}
