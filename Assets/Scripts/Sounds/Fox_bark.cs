using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using events;

public class Fox_bark : MonoBehaviour
{
    [SerializeField] private AudioSource barkEvent;
    [SerializeField] private AudioSource normalBark;
    // Start is called before the first frame update
    void Start()
    {
        normalBark.Play();
        HornetAttackEvent.current.onBarkEvent += BarkEvent;
    }

    public void BarkEvent()
    {
        normalBark.Pause();
        barkEvent.Play();
    }

    public void normal()
    {
        barkEvent.Pause();
        normalBark.Play();
    }

}
