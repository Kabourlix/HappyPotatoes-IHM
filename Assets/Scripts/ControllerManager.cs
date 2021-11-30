using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerManager : MonoBehaviour
{
    public InputActionProperty switchMode;

    private List<GameObject> children;
    private int modeActive;

    // Start is called before the first frame update
    void Start()
    {
        switchMode.action.performed += ctx => PerformSwitchMode();

        children = new List<GameObject>();
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in transform)
        {
            if (child.CompareTag("ControllerMode"))
            {
                children.Add(child.gameObject);
            }
        }

        foreach (GameObject child in children)
        {
            child.SetActive(false);
        }
        modeActive = 0;
        children[modeActive].SetActive(true);
    }

    private void PerformSwitchMode()
    {
        foreach (GameObject child in children)
        {
            child.SetActive(false);
        }
        modeActive = (modeActive + 1) % children.Count;
        children[modeActive].SetActive(true);
    }
}
