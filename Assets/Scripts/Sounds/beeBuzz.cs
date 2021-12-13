using events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeBuzz : MonoBehaviour
{
    public List<AudioSource> happy;
    public List<AudioSource> sad;
    public List<float> delays;
    private bool inCoolDown;

    private void Start()
    {
        launch();
        HornetAttackEvent.current.onSadBees += SadBees;
    }

    // called by Unity when the game starts
    public void HappyBees()
    {
        for (int i = 0; i < happy.Count; i++)
        {
            happy[i].PlayDelayed(delays[i]);
            sad[i].Pause();
        }
    }

    public void SadBees()
    {
        for (int i = 0; i < happy.Count; i++)
        {
            sad[i].PlayDelayed(delays[i]);
            happy[i].Pause();
        }
    }

    public void launch()
    {
        for (int i = 0; i < happy.Count; i++)
        {
            happy[i].PlayDelayed(delays[i]);
        }
    }

    private IEnumerator PlaySadBeeAfterDelay(float delay)
    {
        inCoolDown = true;
        yield return new WaitForSeconds(delay);
        inCoolDown = false;
    }

}
