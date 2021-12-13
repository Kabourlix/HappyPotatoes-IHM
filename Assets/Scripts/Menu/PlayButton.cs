using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 CamStartLocation = new Vector3(0, 2, 0);
    public Quaternion CamStartRotation = Quaternion.Euler(0, 0, 0);
    [SerializeField] private GameObject XRRig;


    public void go2playGround()
    {
        XRRig.transform.position = CamStartLocation;
        XRRig.transform.rotation = CamStartRotation;
    }
}
