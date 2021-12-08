using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public GameObject Menu;
    public GameObject Settings;
    public Button SettingButton;
    public bool disable;


    // Start is called before the first frame update
    void Start()
    {
        disable = true;
        Menu.SetActive(true);
        Settings.SetActive(false);
        Button btn = SettingButton.GetComponent<Button>();
        btn.onClick.AddListener(changeCanvasProperty);
    }

    void changeCanvasProperty()
    {
        disable = !disable;
        Menu.gameObject.SetActive(disable);
        Settings.gameObject.SetActive(!disable);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
