using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBehavior : MonoBehaviour
{
    public Transform[] parents;
    private Transform currentparent;
    public Transform firsttarget; // comment on le généralise
    // Animations of the Bee
    private Animation animations;

    // Comment on peut set des initpositions et intiorientations différentes pour chaque bees et les recup pour les remettre après

    // Life of the Bee
    public float BeeHealth;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        currentparent = parents[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (firsttarget.GetComponent<BeeBehavior>().IsDead )// AJOUTER LA FIN DE L'EVENT QUAND LES FROLONS SONT MORTS? RETOUR AU COMPORTEMENT INIT
        { 
            transform.parent = parents[1];
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
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        isDead = true;
        animations.Play("Death");
        Destroy(transform.gameObject, 5);
    }
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }

    }
}
