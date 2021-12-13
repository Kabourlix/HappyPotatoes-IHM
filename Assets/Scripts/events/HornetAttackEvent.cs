using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace events
{
    public class HornetAttackEvent : GameEvent
    {
        public static HornetAttackEvent current;
        private void Awake()
        {
            current = this;
        }
        public HornetAttackEvent(string _name, GameObject _relatedObject) : base(_name, _relatedObject)
        {
        }

        public override void PlayEventSequence()
        {
            //Init script that make hornet spawn
            
            //Make hornet in attack mode
            
        }

        public event Action onSadBees;
        public event Action onHornets;
        public event Action onBarkEvent;
        public event Action onMusicSpeed;
        public override void PlaySoundSequence()
        {
            //Provide a sound to warn of coming Hornet
            onHornets();
            //Provide a sound for the bees that are sad
            onSadBees();
            //Deal with the dog sounds
            onBarkEvent();
            // Accelerate the ambient music speed 
            onMusicSpeed();
        }
    }
    
}
