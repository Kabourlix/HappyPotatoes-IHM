using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go2menu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Settings;
    public bool disable;

    void Start()
    {
        disable = true;
        Menu.SetActive(true);
        Settings.SetActive(false);
    }
    public void EnableMenu()
    {
        disable = !disable;
        Menu.gameObject.SetActive(disable);
        Settings.gameObject.SetActive(!disable);
    }


}
