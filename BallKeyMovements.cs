using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKeyMovements : MonoBehaviour
{    
 
    public bool turn = false; //boolean check if turning point came or not.
    private GameObject cam; 
    private bool onGround = true;
    public float jumpForce = 500f;
    private rollandMove rollScript;
    private bool waitUntillSecondClick = true; // this is a boolean check variable to prevent abusive movement in horizontal axis.
    private bool getSmaller = true; // this is a boolean check variable to prevent abusive getting smaller.
    private GameObject restartMenu;
    
    
    // Start is called before the first frame update
    void Start()
    {
       
       restartMenu = GameObject.Find("RestartMenu");
    }

    
    // Update is called once per frame
    private void Update()
    {
        

       
        if(transform.position.y < -8)           // for falling down through a hole cases.
        {
            restartMenu.GetComponent<Canvas>().enabled = true;
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && waitUntillSecondClick) // moving left with left arrow key with the click control.
        {
            
            rollScript = this.gameObject.GetComponent<rollandMove>();
            if (turn)   // deciding if arrow key is pressed for moving or turning. Becomes true when the ball collides with turning points.
            {
                cam = GameObject.Find("Main Camera");
                
                if(rollScript.zplus == true)
                {
                    turn = false;
                    globalMovementControl.instance.resetPosition();     // setting the global control integer to 0 for a fresh start at the new level part. 
                    cam.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(20, -90, 0)); // arranging the camera accordingly.
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // set rotation to 0 first.
                    rollScript.xminus = true; // from zplus to xminus turn.
                    rollScript.zplus = false;

                }
                else if(rollScript.zminus == true)
                {
                    turn = false;
                    globalMovementControl.instance.resetPosition();
                    cam.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(20, 90, 0));
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); 
                    rollScript.xplus = true; // from zminus to xplus turn.
                    rollScript.zminus = false;
                }
                else if (rollScript.xplus == true)
                {
                    turn = false;
                    globalMovementControl.instance.resetPosition();
                    cam.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(20, 0, 0));
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); 
                    rollScript.zplus = true; // from xplus to zplus turn.
                    rollScript.xplus = false;
                }
                else if (rollScript.xminus == true)
                {
                    turn = false;
                    globalMovementControl.instance.resetPosition();
                    cam.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(20, 180, 0));
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); 
                    rollScript.zminus = true; // from xminus to zminus turn.
                    rollScript.xminus = false;
                }

               


            }
            else if(globalMovementControl.instance.readPosition() > -1) // global movement int is read -1 if the object is at the very left of the playground. If it is not -1, we can go left.
            {
                if (rollScript.zplus)
                {
                     StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x - 4.5f, transform.position.y, transform.position.z + 3f), 0.2f)); // smooth moving left in Zplus axis.
                }
                else if (rollScript.zminus)
                {
                    StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x + 4.5f, transform.position.y, transform.position.z - 3f), 0.2f)); // smooth moving left in Zminus axis.
                }
                else if (rollScript.xplus)
                {
                    StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x  +3f, transform.position.y, transform.position.z + 4.5f), 0.2f)); // smooth moving left in Xplus axis.

                }
                else if (rollScript.xminus)
                {
                    StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x -3f, transform.position.y, transform.position.z - 4.5f), 0.2f)); // smooth moving left in Xminus axis.

                }

                globalMovementControl.instance.move(-1);

            }

            waitUntillSecondClick = false; 
            StartCoroutine(waitForSecondClick(0.2f)); // controlling the abusive left clicks that may result in unexpected bugs.

        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && waitUntillSecondClick) // moving right with right arrow key with the click control.
        {
            // everything is symmetric with the leftarrow key stroke, look for the comments in there if needed.
            rollScript = this.gameObject.GetComponent<rollandMove>();
            if (turn) 
            {
                cam = GameObject.Find("Main Camera");
                if (rollScript.zplus == true)
                {
                    turn = false;
                    globalMovementControl.instance.resetPosition();
                    cam.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(20, 90, 0));
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); 
                    rollScript.xplus = true; // from zplus to xplus turn.
                    rollScript.zplus = false;

                }
                else if (rollScript.zminus == true)
                {
                    turn = false;
                    globalMovementControl.instance.resetPosition();
                    cam.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(20, -90, 0));
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); 
                    rollScript.xminus = true; // from zminus to xminus turn.
                    rollScript.zminus = false;
                }
                else if (rollScript.xplus == true)
                {
                    turn = false;
                    globalMovementControl.instance.resetPosition();
                    cam.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(20, 180, 0));
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); 
                    rollScript.zminus = true; // from xplus to zminus turn.
                    rollScript.xplus = false;
                }
                else if (rollScript.xminus == true)
                {
                    turn = false;
                    globalMovementControl.instance.resetPosition();
                    cam.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(20, 0, 0));
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); 
                    rollScript.zplus = true; // from xminus to zplus turn.
                    rollScript.xminus = false;
                }
            }
            else if(globalMovementControl.instance.readPosition() < 1)
            {
                if (rollScript.zplus)
                {
                    StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x + 4.5f, transform.position.y, transform.position.z + 3f), 0.2f)); // smooth moving right in Zplus axis.
                }
                else if (rollScript.zminus)
                {
                    StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x - 4.5f, transform.position.y, transform.position.z - 3f), 0.2f)); // smooth moving right in Zminus axis.
                }
                else if (rollScript.xplus)
                {
                    StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z - 4.5f), 0.2f)); // smooth moving right in Xplus axis.

                }
                else if (rollScript.xminus)
                {
                    StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z + 4.5f), 0.2f)); // smooth moving right in Xminus axis.

                }
               
                globalMovementControl.instance.move(+1);

            }


            waitUntillSecondClick = false;
            StartCoroutine(waitForSecondClick(0.2f));


        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround) // jumping up with uparrow key.
        {
            onGround = false;
            rollScript = this.gameObject.GetComponent<rollandMove>();
           
            if (rollScript.zplus)
            {
                StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z + 1f), 0.2f)); // smooth jumping in Zplus axis.
            }
            else if (rollScript.zminus)
            {
                StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x, transform.position.y + 4f, transform.position.z - 1f), 0.2f)); // smooth jumping in Zminus axis.
            }
            else if (rollScript.xplus)
            {
                StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x + 1f, transform.position.y + 4f, transform.position.z), 0.2f)); // smooth jumping in Xplus axis.

            }
            else if (rollScript.xminus)
            {
                StartCoroutine(MoveOverSeconds(gameObject, new Vector3(transform.position.x -1f, transform.position.y + 4f, transform.position.z), 0.2f)); // smooth jumping in Xminus axis.

            }
            

            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && onGround && getSmaller) 
        {
           
            // with alt arrow key, ball gets smaller and 1 second later get bigger.
            StartCoroutine(ChangeSizeOverSeconds(gameObject, transform.localScale/3f , 0.2f)); 
            StartCoroutine(ChangeToNormalSize());
            getSmaller = false;
            StartCoroutine(waitToGetSmaller(1.4f));
          
        }
    }
    private IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds) // this Enumerator uses Vector3.Lerp and time control for smooth movements.
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
    }
    private IEnumerator ChangeSizeOverSeconds(GameObject objectToMove, Vector3 end, float seconds) // this Enumerator uses Vector3.Lerp and time control for smooth size changes.
    {
        float elapsedTime = 0;
        Vector3 startingScale = objectToMove.transform.localScale;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.localScale = Vector3.Lerp(startingScale, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.localScale = end;
    }
    private IEnumerator ChangeToNormalSize() // returning back to normal size after the alt arrow key pressed.
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(ChangeSizeOverSeconds(gameObject, transform.localScale * 3f, 0.2f));
    }
    private IEnumerator waitForSecondClick(float waitTime) // controlling the abusive clicks for horizontal movements.
    {
        yield return new WaitForSeconds(waitTime);
        waitUntillSecondClick = true;
    }
    private IEnumerator waitToGetSmaller(float waitTime) // controlling the abusive clicks for alt arrow key.
    {
        yield return new WaitForSeconds(waitTime);
        getSmaller = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "ground")
        {
            onGround = true;
        }
       else if(collision.gameObject.tag == "obstacle")
        {
            restartMenu.GetComponent<Canvas>().enabled = true;
            Destroy(this.gameObject);
        }
       else if(collision.gameObject.tag == "turnPoint")
        {
            turn = true;
        }
       else if(collision.gameObject.tag == "aligner")
        {
            // at the turning point, align the ball to the center of the new level part.
            StartCoroutine(MoveOverSeconds(gameObject, new Vector3(collision.gameObject.transform.position.x,transform.position.y, collision.gameObject.transform.position.z), 0.1f));
           
        }
    }
}
