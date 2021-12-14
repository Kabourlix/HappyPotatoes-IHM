using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pollutionEvent : eventRefactored.Events.GEvent
{


    public GameObject fog;

    public override void LaunchSequence()
    {
        fog.SetActive(true);
    }

    protected override void EndSequence()
    {
        fog.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
