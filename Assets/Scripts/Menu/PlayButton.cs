using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public Vector3 CamStartLocation = new Vector3(0, 2, 0);
    public Quaternion CamStartRotation = Quaternion.Euler(0, 0, 0);


    // Put camera in X :10070, Y : 2, Z: -7
    // Rotation : 0,-160,0
    // Start is called before the first frame update
    public void go2playGround()
    {
        transform.position = CamStartLocation;
        transform.rotation = CamStartRotation;


    }
}
