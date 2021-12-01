using UnityEngine;

namespace events
{
    public class PotatoEvent : GameEvent
    {
        public PotatoEvent(string _name, GameObject _relatedObject) : base(_name, _relatedObject)
        {
        }

        public override void PlayEventSequence()
        {
            throw new System.NotImplementedException();
        }
    }
}