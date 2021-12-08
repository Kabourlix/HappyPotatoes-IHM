using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class TranslationBees : MonoBehaviour
{
    public float oscillationspeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector3(0.002f*Mathf.Cos(oscillationspeed*Time.time),0.003f*Mathf.Sin(oscillationspeed*Time.time),0));
        gameObject.GetComponent<Animator>().Play("Idle");
    }
}
