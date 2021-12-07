using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackedBees : MonoBehaviour
{

    public Transform firsttarget;
    // Animations of the Bee
    private Animation animations;

    // Life of the Bee
    public float BeeHealth;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        if (firsttarget.GetComponent<AttackedBees>().IsDead){
         GetComponent<TranslationBees>().enabled=false;
         GetComponent<TranslationBees>().enabled=false;
        
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
