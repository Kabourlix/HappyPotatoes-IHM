using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using eventRefactored.Events;
using UnityEngine;
using Random = UnityEngine.Random;

namespace eventRefactored
{
    public class EventsManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] eventRelatedObject; // List the game objects that contains the GEvent
        private List<GEvent> eventStack;

        private GEvent newEvent;
        private GEvent NewEvent
        {
            get => newEvent;
            set
            {
                eventStack.Add(value);
                newEvent = value;
                GEventTriggered(value);
            }
        }

        [SerializeField] private int amountOfDifferentEvents; // Tutorial is not taken into account.
        
        private int eventsTriggerThisMinute;

        private float timer;
        private float Timer
        {
            get => timer;
            set
            {
                timer = value;
                if (!(value < 0f)) return;
                eventsTriggerThisMinute = 0;
                timer = TimeLimit;
            }
        }

        private const float TimeLimit = 60f; //1minutes 
        private int eventRate; // This is the GEvent apparition frequency, in event per minutes.

        private int eventTriggeredSinceBeggining;
        private int EventTriggeredSinceBeggining
        {
            get => eventTriggeredSinceBeggining;
            set
            {
                eventRate = (int) Math.Pow(value,2)/2  + 1; // er = 0.5 x^2 + + 1
                eventTriggeredSinceBeggining = value;
            }
        }
        
        private SettingsManagers settings; // This will be usefull to get world constant and parameters.
        

        public static EventsManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }

            Instance = this;
            Timer = TimeLimit;
            settings = SettingsManagers.Instance;
        }

        private int fact(int i)
        {
            if (i == 0) return 1; 
            int ret = 1;
            for (int k = 1; k <= i; k++)
            {
                ret *= k;
            }

            return ret;
        }

        private float Proba(int rate)
        {
            return fact(60)/(fact(rate) * fact(60 - rate) * Mathf.Pow(60, rate));
        }

        /// <summary>
        /// In the loop Update, we want to randomly generates a event triggers that will change the amountEvent variables,
        /// which will trigger the OnEventTrigger event (C#).
        /// </summary>
        private void Update()
        {
            // We randomly take an event or not.
            if (eventsTriggerThisMinute < eventRate) // We haven't enough event for this minute.
            {
                if (Random.Range(0f, 1f) < Proba(eventRate))
                {
                    eventsTriggerThisMinute += 1;
                    eventTriggeredSinceBeggining += 1;
                    int id = Random.Range(0, amountOfDifferentEvents);
                    NewEvent = eventRelatedObject[id].GetComponent<GEvent>(); // We changed the new event (it is added to the stack)
                    NewEvent.LaunchSequence();
                }
            }
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

        public event Action<GEvent> OnGEventTriggered;

        private void GEventTriggered(GEvent e)
        {
            OnGEventTriggered?.Invoke(e);
        }
        
        //TODO : Deal with deleting event to the fox too.

    }
}
