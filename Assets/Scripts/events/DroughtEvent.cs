using UnityEngine;
using System;

namespace events
{
    public class DroughtEvent : GameEvent
    {
        public static DroughtEvent current;
        private void Awake()
        {
            current = this;
        }
        public DroughtEvent(string _name, GameObject _relatedObject) : base(_name, _relatedObject)
        {
        }

        public event Action onDroughtEvent;
        public override void PlayEventSequence()
        {
            onDroughtEvent();
        }

        public event Action onMusicSpeed;
        public override void PlaySoundSequence()
        {
            onMusicSpeed();
        }
    }
}