using UnityEngine;

namespace events
{
    public class TutorialEvent : GameEvent
    {
        public TutorialEvent(string _name, GameObject _relatedObject) : base(_name, _relatedObject)
        {
        }

        public override void PlayEventSequence()
        {
            throw new System.NotImplementedException();
        }

        public override void PlaySoundSequence()
        {
            throw new System.NotImplementedException();
        }
    }
}