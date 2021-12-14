using System;
using UnityEngine;

namespace events
{
    //! THIS IS OUTDATED DO NOT USE
    public class EventsManager : MonoBehaviour
    {
        [SerializeField] private int eventRate; // In events per minutes

        private SettingsManagers manager;

        private void Start()
        {
            manager = SettingsManagers.Instance;
            //manager.OnGameEventTriggered += ctx => LaunchEvent(ctx);
        }


        private void LaunchEvent(int e_index)
        {
            print("The current index is " + e_index);
            //The current event is e
            //GameEvent e = manager.EventList[e_index];
            //print("Current event is " + e.Name);
            //Play the event itself
            
            //e.PlayEventSequence();
            // Set the movement of the fox towards the event
            manager.IsFoxFollowing = false; 
        }
        
    }
}
