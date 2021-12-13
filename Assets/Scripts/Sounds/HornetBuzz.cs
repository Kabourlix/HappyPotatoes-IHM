using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using events;

public class HornetBuzz : MonoBehaviour
{
    public List<GameObject> hornets;
    public List<float> delays;
    // Start is called before the first frame update
    void Start()
    {
        HornetAttackEvent.current.onHornets += Hornets;
    }

    public void Hornets()
    {
        for (int i = 0; i < hornets.Count; i++)
        {
            PlaySadBeeAfterDelay(delays[i]);
            hornets[i].SetActive(true);
        }
    }
    // Update is called once per frame
    IEnumerator PlaySadBeeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
