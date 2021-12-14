using System;
using UnityEngine;

namespace Fox
{
    public class FoxSound : MonoBehaviour
    {
        private AudioSource audioSource;
        [SerializeField] private AudioClip[] clips;
        [SerializeField] private String[] indexClip;
        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        
        
    }
}
