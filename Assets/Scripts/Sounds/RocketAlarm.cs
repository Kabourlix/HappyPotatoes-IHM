using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using events;

public class RocketAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource alarm;
    // Start is called before the first frame update
    void Start()
    {
        FinalEmergencyEvent.current.onAlarm += Alarm;
    }

    public void Alarm()
    {
        alarm.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
