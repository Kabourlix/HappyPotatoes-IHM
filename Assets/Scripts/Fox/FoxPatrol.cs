using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Fox
{
    public class FoxPatrol : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private List<Transform> targetStack; // This contains the position the fox must go to during event;
        private Transform currentTarget;

        [SerializeField] private float playerRange = 10f;
        [SerializeField] private float eventRange = 3f;

        private bool hasReachedNewEvent; // Boolean to ensure the fox reached a new event before making another one appear.
        private bool hasBarked;
        
        private NavMeshAgent agent;
        private Animator animator;
        private AudioSource audioSource;
        
        private float waitTimer; // This will give the time to wait between each move.
        [SerializeField] private float maxWaitingTimer = 4.0f; // In seconds


        public Transform[] testPositionsEvent;
        public InputAction test;
        private void Start()
        {
            test.Enable();
            test.performed += ctx =>
            {
                print("We added " + testPositionsEvent.Length + " target position to the Mesh agent.");
                foreach (Transform t in testPositionsEvent)
                {
                    targetStack.Add(t);
                }
            };
            
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
                if (Vector3.Distance(player.transform.position, transform.position) < playerRange)
                {
                    animator.SetBool("isIdle",true);
                }
                else
                {
                    animator.SetBool("isIdle",false);
                    agent.SetDestination(player.transform.position); // We move to the player.
                }
                
            }
            else // We have event
            {
                if (currentTarget == null)
                {
                    currentTarget = targetStack[Random.Range(0, targetStack.Count)];
                    animator.SetBool("isIdle", false); // Run animation
                    agent.SetDestination(currentTarget.position);
                }
                //print(Vector3.Distance(transform.position, currentTarget.position));
                if (Vector3.Distance(transform.position, currentTarget.position) < eventRange)
                {
                    print("We reached target");
                    if (!hasBarked)
                    {
                        audioSource.Play(); // We play the bark sound.
                        animator.SetBool("isIdle", true); // We put it on IDLE.
                        hasBarked = true;
                    }

                    
                    waitTimer -= Time.deltaTime; // We decrease wait timer.
                    print(waitTimer);
                    if (waitTimer <= 0)
                    {
                        if (targetStack.Count == 0) return; // We leave the loop to get back to the player following behavior.
                        currentTarget = targetStack[Random.Range(0, targetStack.Count)]; //Otherwise, we change target
                        waitTimer = maxWaitingTimer; // We re-init the timer.
                        animator.SetBool("isIdle", false); // Run animation
                        agent.SetDestination(currentTarget.position);
                        hasBarked = false;
                    }
                }
            }
            
        }
    }
}