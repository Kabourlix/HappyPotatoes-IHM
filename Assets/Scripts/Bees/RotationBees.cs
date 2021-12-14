using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To apply to the center of rotation of a group of bees
public class RotationBees : MonoBehaviour
{
    public float rotationspeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationspeed, 0),Space.Self);
    }
}
