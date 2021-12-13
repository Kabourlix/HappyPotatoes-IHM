using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using events;

public class MusicSpeed : MonoBehaviour
{
    [SerializeField] private AudioSource background;
    // Start is called before the first frame update
    void Start()
    {
        Launch();
        HornetAttackEvent.current.onMusicSpeed += MusicAcc;
    }

    // Update is called once per frame
    public void Launch()
    {
        background.Play();
    }

    public void MusicAcc()
    {
        background.pitch += 0.2f;
    }
}
