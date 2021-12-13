using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (true)
        {
            Ray ray = new Ray(transform.position, Vector3.forward*10);
            RaycastHit hit;
            Debug.DrawRay(transform.position, Vector3.forward,Color.blue);

            if (Physics.Raycast(ray, out hit, 2f))
            {
                print(hit.transform.tag);
                if (hit.transform.tag == "seed")
                {
                    hit.transform.GetComponent<Grow>().grow();
                }
            }
        }
        
    }

    public void OnGrabbed()
    {
        isGrabed = true;
    }
    
    public void ExitGrab()
    {
        isGrabed = false;
    }
}
