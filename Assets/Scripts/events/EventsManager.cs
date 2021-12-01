using System;
using UnityEngine;

namespace events
{
    public class EventsManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] EventObjectList; //! Pay attention this must match manager.nbOfGameEvents
        private int eventRate; // In events per minutes

        private SettingsManagers manager;

        private void Start()
        {
            manager = SettingsManagers.Instance;
        }


        public void LaunchEvent(string eventID)
        {
            //Get the event from the list
            GameEvent currentEvent = manager.EventDict[eventID];
            //Play the event itself
            currentEvent.PlayEventSequence();
            // Set the movement of the fox towards the event
            manager.IsFoxFollowing = false; 
        }
        
    }
}
