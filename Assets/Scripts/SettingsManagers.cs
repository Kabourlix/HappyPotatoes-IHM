using System;
using System.Collections.Generic;
using events;
using UnityEngine;

public class SettingsManagers : MonoBehaviour
{
    
    private GameEvent currentEvent;
    private Dictionary<string, GameEvent> eventDict;

    public Dictionary<string, GameEvent> EventDict { get; private set; }




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
        if (instance != null && instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)
 
        instance = this;
        eventDict = new Dictionary<string, GameEvent>();
    }

    private void Start()
    {
        //TODO : We'll add here the functionning events.
    }
}
