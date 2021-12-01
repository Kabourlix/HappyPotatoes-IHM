using System;
using UnityEngine;

namespace events
{
    public class EventsManager : MonoBehaviour
    {
        [SerializeField] private int eventRate; // In events per minutes

        private SettingsManagers manager;

        private void Start()
        {
            manager = SettingsManagers.Instance;
            manager.OnGameEventTriggered += ctx => LaunchEvent(ctx);
        }


        private void LaunchEvent(GameEvent e)
        {
            //The current event is e;
            //Play the event itself
            e.PlayEventSequence();
            // Set the movement of the fox towards the event
            manager.IsFoxFollowing = false; 
        }
        
    }
}
