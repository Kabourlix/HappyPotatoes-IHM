using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using eventRefactored;
using eventRefactored.Events;

public class Drought : GEvent
{
    [SerializeField] private Material earth;
    [SerializeField] private Material green;
    [SerializeField] private Renderer rend;
    [SerializeField] private GameObject dryPlants;
    [SerializeField] private AudioSource BackgroundMusic;

    public GameObject dryMud;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }
    public override void LaunchSequence()
    {
        DroughtPlane();
        AccMusic();
    }

    protected override void EndSequence()
    {
        GreenPlane();
    }

    public void DroughtPlane()
    {
        rend.material = earth;
        dryPlants.SetActive(false);
    }

    public void GreenPlane()
    {
        rend.material = green;
        dryPlants.SetActive(true);
    }
    
    public void AccMusic()
    {
        BackgroundMusic.pitch += 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        bool isWet = dryMud.GetComponent<Wet>().isWet;
        if (isWet)
        {
            EndSequence();
        }
    }
}
