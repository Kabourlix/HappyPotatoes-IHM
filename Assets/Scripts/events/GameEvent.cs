using UnityEngine;

namespace events
{
    public abstract class GameEvent
    {
        private string name;
        public string Name { get => name;protected set => name = value; }
        private GameObject relatedObject;
        public GameObject RelatedObject { get => relatedObject; set => relatedObject = value; }
        private Transform foxTarget;
        public Transform FoxTarget
        {
            get => foxTarget;
            set
            {
                if (false) foxTarget = value;
            }

        }

        public GameEvent(string _name, GameObject _relatedObject)
        {
            Name = _name;
            relatedObject = _relatedObject;
            FoxTarget = relatedObject.transform;
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