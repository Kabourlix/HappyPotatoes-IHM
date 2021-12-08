using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace events
{
    public class StaticEvent : GameEvent
{
        public StaticEvent(string _name, GameObject _relatedObject) : base(_name, _relatedObject)
        {
        }

        public override void PlayEventSequence()
        {
            throw new System.NotImplementedException();
        }
    }
}