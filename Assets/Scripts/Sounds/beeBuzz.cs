using events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeBuzz : MonoBehaviour
{
    public List<GameObject> happy;
    public List<GameObject> sad;
    public List<float> delays;

    private void Start()
    {
        
        HornetAttackEvent.current.onSadBees += SadBees;
    }

    // called by Unity when the game starts
    public void HappyBees()
    {
        for (int i = 0; i < happy.Count; i++)
        {
            PlaySadBeeAfterDelay(delays[i]);
            sad[i].SetActive(false);
            happy[i].SetActive(true);
        }
    }

    public void SadBees()
    {
        for(int i = 0; i < happy.Count; i++)
        {
            PlaySadBeeAfterDelay(delays[i]);
            happy[i].SetActive(false);
            sad[i].SetActive(true);
        }
    }

    IEnumerator PlaySadBeeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }



}
