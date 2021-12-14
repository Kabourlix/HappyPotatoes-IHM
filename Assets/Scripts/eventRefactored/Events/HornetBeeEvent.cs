
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace eventRefactored.Events
{
    public class HornetBeeEvent : GEvent
    {
        
        public GameObject hornetmodel;
        public Transform inittranform;
        private GameObject hornet1;
        private GameObject hornet2;

        public Transform[] targets;

        public bool hornetsalive;
        
        

        public override void LaunchSequence()
        {
            
            hornet1 = Instantiate(hornetmodel, inittranform.position, inittranform.rotation);
            hornet1.GetComponent<Hornetscript>().targets = targets;
            hornet2 = Instantiate(hornetmodel, inittranform.position, inittranform.rotation);
            hornet2.GetComponent<Hornetscript>().targets = targets;
            hornetsalive = true;
        }


        protected override void EndSequence()
        {
            throw new System.NotImplementedException();
        }

        private void Start()
        {
            ID = 0;
            LaunchSequence();
        }
        // Update is called once per frame
        void Update()
        {
            print(hornet1.GetComponent<Hornetscript>().isDead);
            hornetsalive = (!hornet1.GetComponent<Hornetscript>().isDead && !hornet2.GetComponent<Hornetscript>().isDead);
            if (!hornetsalive)
            {
                Status = false;
            }
        }
    }
}