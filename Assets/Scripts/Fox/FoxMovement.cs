using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using events;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class FoxMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fox;

    private SettingsManagers manager;

    
    
    private Animator foxAnimator;
    private float moveSpeed;
    private const float IdleRange = 5.0f;

    private void Start()
    {
        manager = SettingsManagers.Instance;
        foxAnimator = fox.GetComponent<Animator>();
    }

    private void Update()
    {
        if (manager.IsFoxFollowing)
        {
            FollowingMovement();    
        }
        else
        {
            TowardEventMovement();
            
        }
        
    }

    private void TowardEventMovement()
    {
        //GameEvent e = manager.EventList[manager.CurrentEvent];
        //Transform target = e.FoxTarget;
        //BasicMovementFlow(target,2.0f);
    }
    private void FollowingMovement()
    {
        BasicMovementFlow(player.transform,2.0f);
    }

    private void BasicMovementFlow(Transform target, float speed)
    {
        var pos = projectOnPlane(target.position, 0);
        fox.transform.LookAt(target);
        float targetDistance = (pos - fox.transform.position).magnitude;

        if (targetDistance > IdleRange)
        {
            
            foxAnimator.SetFloat("FoxSpeed",speed);
            //! This possibly prevents gravity from working correctly.
            fox.transform.position = Vector3.MoveTowards(fox.transform.position, pos, foxAnimator.GetParameter(1).defaultFloat);
        }
        else
        {
            foxAnimator.SetFloat("FoxSpeed",0f);
        }
    }

    private Vector3 projectOnPlane(Vector3 pos,int y_value)
    {
        return new Vector3(pos.x, y_value, pos.z);
    }
}
