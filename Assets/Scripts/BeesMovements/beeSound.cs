using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beeSound : MonoBehaviour
{
    public AudioSource happyBeeSound;
    public AudioSource SadBeeSonud;
    public int delay;

    // Start is called before the first frame update
    void Start()
    {
        Happybee();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Happybee()
    {
        StartCoroutine(PlayHappyBeeAfterDelay());
    }
    IEnumerator PlayHappyBeeAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        happyBeeSound.Play();
    }

    public void Sadbee()
    {
        StartCoroutine(PlaySadBeeAfterDelay());
    }
    IEnumerator PlaySadBeeAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        happyBeeSound.Play();
    }


}
