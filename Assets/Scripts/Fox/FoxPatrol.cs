using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Fox
{
    public class FoxPatrol : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private List<Transform> targetStack; // This contains the position the fox must go to during event;
        private Transform currentTarget;

        private bool hasReachedNewEvent; // Boolean to ensure the fox reached a new event before making another one appear.
        private bool hasBarked;
        
        private NavMeshAgent agent;
        private Animator animator;
        private AudioSource audioSource;
        
        private float waitTimer; // This will give the time to wait between each move.
        [SerializeField] private float maxWaitingTimer = 4.0f; // In seconds


        private void Start()
        {
            targetStack = new List<Transform>();
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
            
            waitTimer = maxWaitingTimer; // Init the timer.

            hasReachedNewEvent = false;
            hasBarked = false;
        }

        private void FixedUpdate()
        {
            if (targetStack.Count == 0) // No event in the stack.
            {
                animator.SetBool("isIdle",agent.speed < 0.1f); // We put the animation either on IDLE or Move.
                agent.SetDestination(player.transform.position); // We move to the player.
            }
            else // We have event
            {
                if (currentTarget == null)
                {
                    currentTarget = targetStack[Random.Range(0, targetStack.Count)];
                    animator.SetBool("isIdle", false); // Run animation
                    agent.SetDestination(currentTarget.position);
                }

                if (!(Vector3.Distance(transform.position, currentTarget.position) < 0.2f)) return;
                if (!hasBarked) audioSource.Play(); // We play the bark sound.
                animator.SetBool("isIdle",true); // We put it on IDLE.
                waitTimer -= Time.deltaTime; // We decrease wait timer.
                if (!(waitTimer <= 0)) return;
                if (targetStack.Count == 0) return; // We leave the loop to get back to the player following behavior.
                currentTarget = targetStack[Random.Range(0, targetStack.Count)]; //Otherwise, we change target
                waitTimer = maxWaitingTimer; // We re-init the timer.
                animator.SetBool("isIdle", false); // Run animation
                agent.SetDestination(currentTarget.position);

            }
            
        }
    }
}