using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    //Seed statistics
    private float growthBar;
    private const float maxGrowth = 10f;
    public GameObject grownmodel;

    // Start is called before the first frame update
    void Start()
    {
        growthBar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float a = 1 + 2*growthBar/maxGrowth;
        transform.localScale = new Vector3(a, a, a);
    }

    public void grow()
    {
        growthBar += 0.05f;
        if (growthBar> maxGrowth)
        {
            GameObject grownplant = Instantiate(grownmodel, transform.position, new Quaternion(0,0,0,0),transform.parent);
            Destroy(transform.gameObject);
        }
    }
}
