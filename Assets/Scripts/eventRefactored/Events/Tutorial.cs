using System;
using UnityEngine;

namespace eventRefactored.Events
{
    public class Tutorial : GEvent
    {
        public override void LaunchSequence()
        {
            // Lance la voix de début de Margaux, je le dirige vers machin
            
            // Je met mon boolean sur true.
            
            // Première quête 
        }

        protected override void EndSequence()
        {
            throw new System.NotImplementedException();
        }

        private void Update()
        {
            //if first quest accomplished
            SecondQuest();
        }

        private void SecondQuest()
        {
            
        }
    }
}