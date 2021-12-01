using UnityEngine;

namespace events
{
    public class EventsManager : MonoBehaviour
    {
        private int[] eventListID;
        [SerializeField] private GameObject[] events;
        private int eventRate; // In events per minutes


        public void LaunchEvent(int eventID)
        {
            //Get the event from the list
            GameObject current_event = (GameObject) events.GetValue(eventID);
            //Play the event itself
            
            // Set the movement of the fox towards the event
            
        }
        
    }
}
