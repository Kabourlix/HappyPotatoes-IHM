using System;
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
        private AudioSource audioSource;
        private int currentClip;
        public override void LaunchSequence()
        {
            //First sound of the intro.
            audioSources[currentClip].Play();
            currentClip++;
            //Fox appearance
            audioSources[currentClip].PlayDelayed(13f);
            manager.isFoxFollowing = true;
            
            fox.GetComponent<AudioSource>().clip = doggoClips[0];
            fox.GetComponent<AudioSource>().volume = 0.3f;
            fox.GetComponent<AudioSource>().PlayDelayed(19);
            print(currentClip);
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
            }
            manager = EventsManager.Instance;
            
            currentClip = 0;
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