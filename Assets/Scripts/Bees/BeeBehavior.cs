using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehavior : MonoBehaviour
{
    public Transform[] parents;
    private Transform currentparent;
    private Transform inittransform;
    public Transform firsttarget; // comment on le généralise
    // Animations of the Bee
    private Animator animations;

    // Comment on peut set des initpositions et intiorientations différentes pour chaque bees et les recup pour les remettre après

    // Life of the Bee
    public float BeeHealth;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        animations = gameObject.GetComponent<Animator>();
        currentparent = parents[0];
        inittransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Behavior during the hornetevent, after the death of the firstbee
        if (firsttarget.GetComponent<BeeBehavior>().IsDead && !isDead) //&& Time.time<60
        { 
            transform.parent = parents[1];
            animations.Play("Move");
        }
        //Behavior after the hornetevent
        /*else if(firsttarget.GetComponent<BeeBehavior>().IsDead && Time.time>60)// behavior évènement
        {
            transform.parent = parents[0];
            transform.position=inittransform.position;
            transform.rotation = inittransform.rotation;

        }*/
        if (isDead)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0f, transform.position.z), 0.05f);
            GetComponent<TranslationBees>().enabled = false;
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
