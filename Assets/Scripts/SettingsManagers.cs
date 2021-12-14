using System;
using System.Collections.Generic;
using events;
using UnityEngine;
using UnityEngine.InputSystem;

public class SettingsManagers : MonoBehaviour
{
    private bool isFoxFollowing;

    public bool IsFoxFollowing
    {
        get => isFoxFollowing;
        set => isFoxFollowing = value;
    }

    private int currency;

    public int Currency
    {
        get => currency;
        set
        {
            currency = value;
            CurrencyChange(value);
        }
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
        Currency = 200; // Init the currency value.
    }
    

   
    public event Action<int> OnCurrencyChange;

    private void CurrencyChange(int new_value)
    {
        OnCurrencyChange?.Invoke(new_value);
    }
}
