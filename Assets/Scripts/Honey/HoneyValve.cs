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
    private float inityrotation;
    

    //Honey spawning
    public GameObject originalhoney;
    private bool honeyinstock;
    private float timeinterval;
    private float tick;
    private Vector3 inithoneyposition;

    // Start is called before the first frame update
    void Start()
    {
        inityrotation = transform.rotation.y;
        honeyinstock = false;
        timeinterval = 10f;
        tick = timeinterval;
        inithoneyposition = originalhoney.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        //bool open = Mathf.Abs(transform.rotation.y - inityrotation) > 90;
        bool open = true;
        
        if((int)Time.time == tick)
        {
            honeyinstock = true; 
        }
        print(honeyinstock);
        // if the valve is open
        if (open && honeyinstock)
        {
            honeymelting();
            inityrotation = transform.rotation.y;
            tick = Time.time + timeinterval;
            honeyinstock = false;
        }
    }

    void OnSelectEnter()
    {
        targetPosition = target.transform.position;

        if (Vector3.Distance(transform.eulerAngles, targetPosition) > 0.01f )
        {
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, targetPosition, Time.time * speed);
        }
    }
    void OnSelectExited()
    {
        inityrotation = transform.rotation.y;
    }

    public void honeymelting()
    {
        // Dupplication
        GameObject o = Instantiate(originalhoney);
        o.GetComponent<Rigidbody>().useGravity = false;
        o.transform.position = inithoneyposition;
        o.transform.parent = originalhoney.transform.parent;
        o.transform.localScale= new Vector3(8,8,8);

        //Melting
        originalhoney.GetComponent<Rigidbody>().useGravity = true;

        // Instantiation
        originalhoney = o;

    }
}
