using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wet : MonoBehaviour
{
    //Seed statistics
    public bool isWet; 
    private float wetBar;
    private const float maxWet = 10f;

    // Start is called before the first frame update
    void Start()
    {
        isWet = false;
        wetBar = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void wet()
    {
        // Modification of the statistics
        wetBar += 0.05f;
        if (wetBar > maxWet)
        {
            isWet = true;
        }
    }
}
