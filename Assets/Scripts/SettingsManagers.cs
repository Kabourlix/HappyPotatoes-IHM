using System;
using UnityEngine;

public class SettingsManagers : MonoBehaviour
{
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
    }
  
    
    // here we find all the actions and eventListeners
    public event Action<bool> OnFoxMovementChanged;
    public void FoxMovementChanged(bool status)
    {
        OnFoxMovementChanged?.Invoke(status);
    }


}
