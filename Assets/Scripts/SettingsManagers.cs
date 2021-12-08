using System;
using System.Collections.Generic;
using events;
using UnityEngine;
using UnityEngine.InputSystem;

public class SettingsManagers : MonoBehaviour
{
    // Temporary for testing
    public InputAction eventInput;
    /// 
    [SerializeField] private GameObject[] eventsObject;

    private GameEvent[] eventList;
    public GameEvent[] EventList { 
        get => eventList;
        set
        {
            if(false)
            {
                eventList = value;
            }   
        } }
    
    private int currentEvent;

    public int CurrentEvent
    {
        get => currentEvent;
        set
        {
            currentEvent = value;
            GameEventTriggered(value);
        }
    }


    private bool isFoxFollowing;

    public bool IsFoxFollowing
    {
        get => isFoxFollowing;
        set => isFoxFollowing = value;
    }
    
    private static SettingsManagers instance;
    private SettingsManagers(){} //au cas où certains fous tenteraient qd même d'utiliser le mot clé "new"
    
    // Méthode d'accès statique (point d'accès global)
    public static SettingsManagers Instance { get; private set; }
 
    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)
 
        Instance = this;
        IsFoxFollowing = true;
        eventList = new GameEvent[eventsObject.Length];
        eventList[0] = new PotatoEvent("potato",eventsObject[0]);
    }

    private void Start()
    {
        
        
        //TODO : We'll add here the functionning events.
        
        eventInput.Enable();
        eventInput.performed += ctx =>
        {
            print("The R key is pressed");
            CurrentEvent = 0;
        };
    }

    public event Action<int> OnGameEventTriggered;

    private void GameEventTriggered(int e_index)
    {
        OnGameEventTriggered?.Invoke(e_index);
    }
}
