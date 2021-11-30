using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fox;

    private Animator foxAnimator;
    private float moveSpeed;
    private const float IdleRange = 5.0f;

    private void Start()
    {
        foxAnimator = fox.GetComponent<Animator>();
    }

    private void Update()
    {
        fox.transform.LookAt(player.transform);
        float targetDistance = (player.transform.position - fox.transform.position).magnitude;

        if (targetDistance > IdleRange)
        {
            
            foxAnimator.SetFloat("FoxSpeed",2.0f);
            //! This possibly prevents gravity from working correctly.
            fox.transform.position = Vector3.MoveTowards(fox.transform.position, player.transform.position, foxAnimator.GetParameter(1).defaultFloat);
        }
        else
        {
            foxAnimator.SetFloat("FoxSpeed",0f);
        }
    }
}
