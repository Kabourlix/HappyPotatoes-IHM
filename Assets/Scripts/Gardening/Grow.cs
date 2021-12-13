using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    //Seed statistics
    private float growthBar;
    private const float maxGrowth = 10f;
    public object grownmodel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void grow()
    {
        growthBar += 0.5f;
        if (growthBar> maxGrowth)
        {

        }
    }
}
