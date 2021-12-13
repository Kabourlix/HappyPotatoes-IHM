using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoneyValve : MonoBehaviour
{
    //To interact with the valve
    public GameObject target;
    public float speed = 0.01f;
    private Vector3 targetPosition;
    private Transform inittransform;
    private float inityrotation;
    private bool isHold;
    

    //Honey spawning
    public GameObject originalhoney;
    private bool honeyinstock;
    private float timeinterval;
    private float tick;
    private Vector3 inithoneyposition;

    // Start is called before the first frame update
    void Start()
    {
        // About the valve
        inittransform = transform;
        inityrotation = inittransform.rotation.y;
        isHold = false;

        //About the honey
        honeyinstock = false;
        timeinterval = 30f;
        tick = timeinterval;
        inithoneyposition = originalhoney.transform.position;
        originalhoney.GetComponent<XRGrabInteractable>().enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // Movement of the valve if it's hold
        if (isHold)
        {
            targetPosition = target.transform.position;

            if (Vector3.Distance(transform.eulerAngles, targetPosition) > 0.01f)
            {
                Quaternion a = new Quaternion(inittransform.rotation.x, Mathf.Acos((transform.position.x - targetPosition.x) / (transform.position.z - targetPosition.z)), inittransform.rotation.z, inittransform.rotation.w);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, a, Time.time * speed);
            }
        }
        // Verifying that the distance is enough so that the valve is open
        bool open = Mathf.Abs(transform.rotation.y - inityrotation) > 90;
        
        // if there is honey in stock
        if((int)Time.time == tick)
        {
            honeyinstock = true; 
        }

        // if the valve is open and there is honey in stock
        if (open && honeyinstock)
        {
            honeymelting();
            inityrotation = transform.rotation.y;
            tick = Time.time + timeinterval;
            honeyinstock = false;
        }
    }

    public void OnSelectEntered()
    {
        isHold = true;
    }
    public void OnSelectExited()
    {
        isHold = false; 
        inityrotation = transform.rotation.y;
    }

    public void honeymelting()
    {
        // Dupplication
        GameObject o = Instantiate(originalhoney, inithoneyposition, new Quaternion(0,0,0,0),originalhoney.transform.parent);
        o.GetComponent<Rigidbody>().useGravity = false;
        o.GetComponent<XRGrabInteractable>().enabled = false;
        o.transform.localScale= new Vector3(8,8,8);

        //Melting
        originalhoney.GetComponent<XRGrabInteractable>().enabled = true;
        originalhoney.GetComponent<Rigidbody>().useGravity = true;

        // Instantiation
        originalhoney = o;
    }
}
