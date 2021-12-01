using UnityEngine;

namespace events
{
    public class GameEvent
    {
        private string name;
        public string Name { get; private set; }
        private GameObject relatedObject;
        private Transform foxTarget;
        public Transform FoxTarget { get; private set; }

        public GameEvent(string _name, GameObject _relatedObject)
        {
            Name = _name;
            relatedObject = _relatedObject;
            foxTarget = relatedObject.transform;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                GameEvent e = (GameEvent) obj;
                return e.Name.Equals(this.Name);    
            }
        }

        public void PlayEventSequence()
        {
            //TODO : Add code here;
        }
    }
}