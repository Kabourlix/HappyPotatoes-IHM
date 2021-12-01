using UnityEngine;

namespace events
{
    public class Event
    {
        private string name;
        private GameObject relatedObject;
        private Vector3 foxTarget;
        public Vector3 FoxTarget { get; private set; }

        public Event(string _name, GameObject _relatedObject)
        {
            name = _name;
            relatedObject = _relatedObject;
            foxTarget = relatedObject.transform.position;
        }
    }
}