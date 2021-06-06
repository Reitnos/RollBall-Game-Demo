using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public GameObject gateOpen1, gateOpen2, arrowOpen2, gateClose1,arrowClose1, triggerClose,triggerOpen;
    public GameObject[] levels;
    public GameObject lastLevel;
    private GameObject newLevel;
    private int random;

    
    private void OnCollisionEnter(Collision collision) // controlling the gates in the scene, opening and closing the given gates and arrows.
    {
        if(collision.gameObject.tag == "player")
        {
            if (gateOpen1 != null)
            {
            gateOpen1.SetActive(true);

            }
            
            if(gateOpen2 != null)
            {
            gateOpen2.GetComponent<MeshRenderer>().enabled = true;
            gateOpen2.GetComponent<BoxCollider>().enabled = true;
            }
            
            if(arrowOpen2 != null)
            {

            arrowOpen2.SetActive(true);
            }
           
            
            if(gateClose1 != null)
            {

            gateClose1.GetComponent<MeshRenderer>().enabled = false;
            gateClose1.GetComponent<BoxCollider>().enabled = false;
            }

            
            if(arrowClose1 != null)
            {
            arrowClose1.SetActive(false);

            }
       

            if(triggerClose != null)
            {
            triggerClose.GetComponent<BoxCollider>().enabled = false;

            }
           
            if(triggerOpen != null)
            {
            triggerOpen.GetComponent<BoxCollider>().enabled = true;

            }

            //****
            // here the most previous level part is destroyed and replaced with a random level part,
            // so that the same game scene results in lots of different combinations.
            //****
            random = Random.Range(0, 10);
            newLevel = Instantiate(levels[random], lastLevel.transform.position, lastLevel.transform.rotation);
            Destroy(lastLevel);
            lastLevel = newLevel;
            

           
        }
    }
}
