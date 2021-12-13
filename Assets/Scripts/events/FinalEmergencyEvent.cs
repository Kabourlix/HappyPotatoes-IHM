using UnityEngine;
using System;

namespace events
{
    public class FinalEmergencyEvent : GameEvent
    {
        public static FinalEmergencyEvent current;
        private void Awake()
        {
            current = this;
        }
        public FinalEmergencyEvent(string _name, GameObject _relatedObject) : base(_name, _relatedObject)
        {
        }

        public override void PlayEventSequence()
        {
            throw new System.NotImplementedException();
        }

        public event Action onAlarm;
        public override void PlaySoundSequence()
        {
            //  Alarm of the rocket
            onAlarm();
        }
    }
}