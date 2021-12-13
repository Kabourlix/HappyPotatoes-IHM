using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wateringcan : MonoBehaviour
{
    // If the can is grabbed
    private bool isGrabbed;

    // Start is called before the first frame update
    void Start()
    {
        isGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbed)
        {
            Transform initpointray = transform.Find("Raybegin").transform;
            Ray ray = new Ray(initpointray.position, Vector3.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.transform.tag == "seed")
                {
                    //hit.transform.GetComponent<>();
                }
            }
        }
        
    }

    public void OnGrabbed()
    {
        isGrabbed = true;
    }
    
    public void ExitGrab()
    {
        isGrabbed = false;
    }
}
