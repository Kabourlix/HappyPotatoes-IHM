using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// to add to the point at the spout of the wateringcan
public class Wateringcan : MonoBehaviour
{
    // If the can is grabbed
    private bool isGrabed;
    

    // Start is called before the first frame update
    void Start()
    {
        isGrabed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Verifying that the wateringcan is grabed
        if (isGrabed)
        {
            // the ray represent a ray of water 
            Ray ray = new Ray(transform.position,transform.forward*10);
            
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward,Color.blue);

            //if it hits the collider of a seed, the seed will grow
            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.transform.tag == "seed")
                {
                    hit.transform.GetComponent<Grow>().grow();
                }
            }
        }
        
    }

    // update the value of isgrabed, is called with the OnSelectEntered() of the XR grab Interactor of the wateringcan
    public void OnGrabbed()
    {
        isGrabed = true;
    }

    // update the value of isgrabed, is called with the OnSelectExited() of the XR grab Interactor of the wateringcan
    public void ExitGrab()
    {
        isGrabed = false;
    }
}
