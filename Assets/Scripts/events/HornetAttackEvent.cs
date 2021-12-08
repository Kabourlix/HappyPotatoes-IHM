using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace events
{
    public class HornetAttackEvent : GameEvent
    {
        public HornetAttackEvent(string _name, GameObject _relatedObject) : base(_name, _relatedObject)
        {
        }

        public override void PlayEventSequence()
        {
            //Init script that make hornet spawn
            
            //Make hornet in attack mode
            
        }

        public override void PlaySoundSequence()
        {
            //Provide a sound to warn of coming bees
            
            //Deal with the dog sounds
            
            // Accelerate the ambient music speed 
        }
    }
    
}
