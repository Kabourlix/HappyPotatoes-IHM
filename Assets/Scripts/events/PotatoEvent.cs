using UnityEngine;
using UnityEngine.InputSystem.Interactions;

namespace events
{
    public class PotatoEvent : GameEvent
    {
        public PotatoEvent(string _name, GameObject _relatedObject) : base(_name, _relatedObject)
        {
        }

        public override void PlayEventSequence()
        {
            RelatedObject.transform.position += Vector3.up*10;
        }

        public override void PlaySoundSequence()
        {
            
        }
    }
}