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
    
    
    
    
    
    private GameEvent currentEvent;

    public GameEvent CurrentEvent
    {
        get => CurrentEvent;
        set
        {
            
            if (value != null)
            {
                CurrentEvent = value;
                GameEventTriggered(value);
            }
            else // We come back to the initial state;
            {
                IsFoxFollowing = true;
            }
        }
    }

    private Dictionary<string, GameEvent> eventDict;

    public Dictionary<string, GameEvent> EventDict { get; private set; }

    [SerializeField] private GameObject potatoObjectEvent;



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
        EventDict = new Dictionary<string, GameEvent>();
        CurrentEvent = null;
    }

    private void Start()
    {
        
        //TODO : We'll add here the functionning events.
        EventDict.Add("potato",new PotatoEvent("potato", potatoObjectEvent));
        eventInput.Enable();
        eventInput.performed += ctx =>
        {
            print("The R key is pressed");
            //CurrentEvent = EventDict["potato"];
            CurrentEvent = new PotatoEvent("potato", potatoObjectEvent);
        };
    }
    
    public event Action<GameEvent> OnGameEventTriggered;

    public void GameEventTriggered(GameEvent e)
    {
        OnGameEventTriggered?.Invoke(e);
    }
}
