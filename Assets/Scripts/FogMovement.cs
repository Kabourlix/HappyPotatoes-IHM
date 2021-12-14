using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Attached with camera offset and not to maincamera, so that the fog doesn't turn with the vision
//Otherwise the fog is static
public class FogMovement : MonoBehaviour
{
    
    [SerializeField] private Camera maincamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // follow the main camera position but not its rotation
        transform.SetPositionAndRotation(maincamera.transform.position, new Quaternion(0,0,0,0));
    }
}
