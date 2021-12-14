using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To add to a seed
public class Grow : MonoBehaviour
{
    //Seed statistics
    private float growthBar;
    private const float maxGrowth = 10f;

    // The grown model
    public GameObject grownmodel;

    // Start is called before the first frame update
    void Start()
    {
        growthBar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // The seed grown in scale with its growthbar
        float a = 1 + 2*growthBar/maxGrowth;
        transform.localScale = new Vector3(a, a, a);
    }

    public void grow()
    {
        // Modification of the statistics
        growthBar += 0.05f;
        if (growthBar> maxGrowth)
        {
            // Apparition of the new grown plant
            Vector3 position = new Vector3(transform.position.x, -1.15473e-05f  , transform.position.z);
            GameObject grownplant = Instantiate(grownmodel, transform.position, new Quaternion(0,0,0,0),transform.parent);
            grownplant.AddComponent<Rigidbody>();
            grownplant.GetComponent<Rigidbody>().useGravity=true;

            // Destruction of the seed
            Destroy(transform.gameObject);
        }
    }
}
