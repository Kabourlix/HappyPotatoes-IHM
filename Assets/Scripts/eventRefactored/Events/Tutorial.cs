using System;
using System.Security.Cryptography;
using Fox;
using UnityEngine;
using UnityEngine.Serialization;

namespace eventRefactored.Events
{
    public class Tutorial : GEvent
    {
        
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject playerAudioSourceGameObject;
        [SerializeField] private GameObject fox;
        [SerializeField] private AudioClip[] doggoClips;
        private AudioSource[] audioSources;
        private int currentClip;

        [SerializeField] private Transform[] foxPos;

        [SerializeField] private GameObject musiqueObject;

        private int currentQuest = 1;
        
        //TP 
        [SerializeField] private GameObject tpArea;
        [SerializeField] private GameObject tpArea2Potatoes;
        public override void LaunchSequence()
        {
            //First sound of the intro.
            audioSources[currentClip].Play();
            currentClip++;
            //Fox appearance
            audioSources[currentClip].PlayDelayed(13f);
            manager.isFoxFollowing = true;
            currentClip++;
            
            fox.GetComponent<AudioSource>().clip = doggoClips[0];
            fox.GetComponent<AudioSource>().volume = 0.3f;
            fox.GetComponent<AudioSource>().PlayDelayed(19);
            
            //Teleport show
            audioSources[currentClip].PlayDelayed(29.5f);
            currentClip++;
            audioSources[currentClip].PlayDelayed(42f);
            currentClip++;
        }

        protected override void EndSequence()
        {
            throw new System.NotImplementedException();
        }
        
        private void Start()
        {
            int i = playerAudioSourceGameObject.transform.GetComponentsInChildren<Transform>().Length;
            audioSources = new AudioSource[i];
            int k = 0;
            foreach (Transform t in playerAudioSourceGameObject.transform)
            {
                audioSources[k] = t.GetComponent<AudioSource>();
                k++;
            }
            manager = EventsManager.Instance;
            
            currentClip = 0;
        }

        private void Update()
        {
            switch (currentQuest)
            {
                case 1 : //TP
                    if (tpArea.GetComponent<TpAreaScript>().isPlayerEntered)
                    {
                        musiqueObject.SetActive(true);
                        currentQuest++;
                        tpArea.transform.position = tpArea2Potatoes.transform.position;
                        audioSources[currentClip].Play();
                        currentClip++;
                        foreach (Transform t in foxPos)
                        {
                            fox.GetComponent<FoxPatrol>().AddTargetManually(t);
                        }
                    }
                    break;
                case 2 : // Go to potatoes
                    audioSources[currentClip].PlayDelayed(10f);
                    if (tpArea.GetComponent<TpAreaScript>().isPlayerEntered)
                    {
                        currentClip++;
                        currentQuest++;
                        tpArea.SetActive(false);
                        audioSources[currentClip].Play();
                        currentClip++;
                    }
                    break;
                
                case 3 : // The shop

                    break;
            }
        }
        
    }
}