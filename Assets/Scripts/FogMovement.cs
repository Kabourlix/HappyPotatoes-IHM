using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera maincamera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(maincamera.transform.position, new Quaternion(0,0,0,0));
    }
}
