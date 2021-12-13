using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using events;

public class PlaneChanges : MonoBehaviour
{

    [SerializeField] private Material earth;
    [SerializeField] private Material green;
    [SerializeField] private Renderer rend;
    [SerializeField] private GameObject dryPlants;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        launch();
        DroughtPlane();
        DroughtEvent.current.onDroughtEvent += DroughtPlane;
    }

    // Update is called once per frame
    public void DroughtPlane()
    {
        rend.material = earth;
        dryPlants.SetActive(false);
    }

    public void launch()
    {
        rend.material = green;
    }
}
