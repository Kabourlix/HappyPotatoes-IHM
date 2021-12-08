using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digging : MonoBehaviour
{

    public GameObject mud;
    private int maxHits;
    private int nbHits;

    // Start is called before the first frame update
    void Start()
    {
        mud.SetActive(false);
        maxHits = 10;
        nbHits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shovel")
        {
            if (nbHits >= maxHits)
            {
                mud.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                nbHits++;
            }
        }
    }
}
