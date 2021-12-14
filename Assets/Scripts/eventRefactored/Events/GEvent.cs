using System;
using UnityEngine;

namespace eventRefactored.Events
{
    /// <summary>
    /// This class contains the information needed for each event.
    /// Each event will be its own class inherited from GEvent.
    /// </summary>
    public abstract class GEvent : MonoBehaviour
    {
        // Attributes
        public int ID { get; private set;}

        private bool Status
        {
            get => Status;
            set
            {
                if (value) return;
                EndSequence();
                manager.DeleteGEventFromStack(ID);
            }
        } //true if on going, false if to be ended.
        
        private EventsManager manager;


        private void Awake()
        {
            manager = EventsManager.Instance;
        }
        
        /// <summary>
        /// This function is the core of the GEvent.
        /// It is here that must be placed all the init action of an event :
        ///     - Instantiates GameObjects
        ///     - Change Fox Target
        ///     - Activate mode (for exemple Hornet following bees mode)
        /// </summary>
        public abstract void LaunchSequence();
        
        /// <summary>
        /// This function will end the GEvent.
        /// It is called when all condition are united to end the event (This will be changed in the Update loop).
        /// Therefore, any destruction, mode changes et fox behavior must be readjusted in consequences here.
        /// </summary>
        protected abstract void EndSequence();
    }
}
