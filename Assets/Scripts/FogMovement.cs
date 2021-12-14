using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMovement : MonoBehaviour
{
    // Important : attached with camera offset and not to maincamera!
    [SerializeField] private Camera maincamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(maincamera.transform.position, new Quaternion(0,0,0,0));
    }
}
