using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using eventRefactored.Events;
using UnityEngine;

namespace eventRefactored
{
    public class EventsManager : MonoBehaviour
    {
        private List<GEvent> eventStack;
        
        private GEvent NewEvent
        {
            get => NewEvent;
            set => eventStack.Add(value);
        }

        private int eventRate; // This is the GEvent apparition frequency, in event per minutes.

        private SettingsManagers settings; // This will be usefull to get world constant and parameters.

        public static EventsManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }

            Instance = this; 
            
            settings = SettingsManagers.Instance;
        }

        /// <summary>
        /// In the loop Update, we want to randomly generates a event triggers that will change the amountEvent variables,
        /// which will trigger the OnEventTrigger event (C#).
        /// </summary>
        private void Update()
        {
            // We randomly take an event or not.
            
            //If we add one, we launch sequence
            
        
        }

        public void DeleteGEventFromStack(int id)
        {
            foreach (var gEvent in eventStack.Where(gEvent => gEvent.ID == id))
            {
                eventStack.Remove(gEvent);
                break;
            }
        }
        
    }
}
