using System.Collections;
using System.Collections.Generic;
using eventRefactored;
using eventRefactored.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Settings;
    public bool disable;

    private EventsManager eventManager;
    [SerializeField] private GameObject tutorialGameObject;

    [SerializeField] private GameObject player;


    public InputAction test;
    private void Start()
    {
        test.Enable();
        test.performed += ctx =>
        {
            PlayButton();
        };
        disable = true;
        Menu.SetActive(true);
        Settings.SetActive(false);
        eventManager = EventsManager.Instance;
    }
    public void EnableMenu()
    {
        disable = !disable;
        Menu.gameObject.SetActive(disable);
        Settings.gameObject.SetActive(!disable);
    }

    public void PlayButton()
    {
        player.transform.position = new Vector3(5, 0, 30);
        player.transform.rotation = Quaternion.identity;
        eventManager.isTutorialOn = true;
        eventManager.isFoxFollowing = false;
        tutorialGameObject.GetComponent<GEvent>().LaunchSequence();
    }


}
