using UnityEngine;

namespace events
{
    public class PollutionEvent : GameEvent
    {
        
        
        public PollutionEvent(string _name, GameObject _relatedObject) : base(_name, _relatedObject)
        {

        }

        public override void PlayEventSequence()
        {
            //Apparition of fog

            //Unlocking seeds in PorkShop

            //Enable Seed planting
        }

        public override void PlaySoundSequence()
        {
            throw new System.NotImplementedException();
        }

        
    }
}