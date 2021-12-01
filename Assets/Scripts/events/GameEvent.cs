using UnityEngine;

namespace events
{
    public abstract class GameEvent
    {
        private string name;
        public string Name { get; private set; }
        private GameObject relatedObject;
        public GameObject RelatedObject { get; set; }
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

        public abstract void PlayEventSequence();

    }
}