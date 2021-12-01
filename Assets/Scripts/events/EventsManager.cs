﻿using System;
using UnityEngine;

namespace events
{
    public class EventsManager : MonoBehaviour
    {
        private int[] eventListID;
        private int eventRate; // In events per minutes

        private SettingsManagers manager;

        private void Start()
        {
            manager = SettingsManagers.Instance;
        }


        public void LaunchEvent(int eventID)
        {
            //Get the event from the list
            GameEvent currentEvent = (GameEvent) manager.Events.GetValue(eventID);
            //Play the event itself
            currentEvent.PlayEventSequence();
            // Set the movement of the fox towards the event
            manager.IsFoxFollowing = false; 
        }
        
    }
}
