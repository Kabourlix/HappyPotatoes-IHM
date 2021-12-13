using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class BeeBehavior : MonoBehaviour
{
    public Transform[] parents;
    private Transform currentparent;
    private Transform inittransform;
    public Transform firsttarget; // comment on le généralise

    //Speed of oscillation
    public float oscillationspeed = 1.0f;

    // Animations of the Bee
    private Animator animations;

    // Agent of navigation
    private NavMeshAgent agent;

    // boolean of normal behavior
    private bool normalbehavior;

    // Life of the Bee
    public float BeeHealth;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        animations = gameObject.GetComponent<Animator>();
        currentparent = parents[0];
        inittransform = transform;
        normalbehavior = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0f, transform.position.z), 0.05f);
            GetComponent<TranslationBees>().enabled = false;
        }
        else
        {
            // Behavior during the hornetevent, after the death of the firstbee
            if (firsttarget.GetComponent<BeeBehavior>().IsDead && false)
            {
                transform.parent = parents[1];
                animations.Play("Move");
                normalbehavior = false;
            }

            //Behavior just after the hornetevent 
            else if (firsttarget.GetComponent<BeeBehavior>().IsDead && !normalbehavior)
            {
                if (transform.position == inittransform.position)
                {
                    transform.rotation = inittransform.rotation;
                    normalbehavior = true;
                }
                transform.parent = parents[0];
                agent.destination = inittransform.position;
            }

            // Normal Behavior
            else
            {
                transform.Translate(new Vector3(0.002f * Mathf.Cos(oscillationspeed * Time.time), 0.001f * Mathf.Sin(oscillationspeed * Time.time), 0));
                gameObject.GetComponent<Animator>().Play("Idle");
            }
        }
    }

    public void ApplyDammage(float TheDammage)
    {
        if (!isDead)
        {
            BeeHealth = BeeHealth - TheDammage;
            animations.Play("Damage");
            if (BeeHealth <= 0)
            {
                Dead();
            }
        }
    }

    public void Dead()
    {
        transform.parent = parents[2];
        isDead = true;
        animations.Play("Death");
        Destroy(transform.gameObject, 15);
    }
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }

    }
}
