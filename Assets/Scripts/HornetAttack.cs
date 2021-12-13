using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HornetAttack : MonoBehaviour
{

    // Distance between the bee or the player  and the hornet
    private float TargetDistance;
    private float Playerdistance;

    // List of potential
    public Transform currenttarget;
    public Transform[] targets;
    public Transform Player;

    // Sound when the shovel hits the hornet
    public AudioSource hit;

    //Distance of pursuit
    public float chaseRange = 10;

    // Range of the attacks
    public float attackRange = 2.2f;

    // Cooldown of attacks
    public float attackRepeatTime = 1;
    private float attackTime;

    // Amount of the inflicted dammage
    public float TheDammage;

    // Agent de navigation
    private NavMeshAgent agent;

    // Animations  of the enemy
    private Animator animations;

    // Life of the enemy
    public float enemyHealth;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        animations = gameObject.GetComponent<Animator>();
        attackTime = Time.time;
        print(agent);
    }

    // Update is called once per frame
    void Update()
    {
        updatetarget();

        // On calcule la distance entre le joueur et l'enemy, en fonction de cette distance on effectue diverses actions
        TargetDistance = Vector3.Distance(currenttarget.position, transform.position);

        // Quand l'ennemi est proche mais pas assez pour attaquer
        if (TargetDistance < chaseRange && TargetDistance > attackRange)
        {
            chase();
        }

        // Quand l'enemy est assez proche pour attaquer
        if (TargetDistance < attackRange)
        {
            attack();
        }
    }

    // pursuit
    void chase()
    {
        animations.Play("Move");
        agent.destination = currenttarget.position;
    }

    void attack()
    {
        // empeche l'enemy de traverser le joueur
        agent.destination = transform.position;

        //Si pas de cooldown
        if (Time.time > attackTime)
        {
            animations.Play("Attack");
            //currenttarget.GetComponent<BeeBehavior>().ApplyDammage(TheDammage);

            //Debug.Log("L'ennemi a envoyÃ© " + TheDammage + " points de dÃ©gÃ¢ts");
            attackTime = Time.time + attackRepeatTime;
        }
    }

    public void ApplyDammage(float TheDammage)
    {

        Debug.Log("in dammage");
        Debug.Log("ennemy health: " + enemyHealth.ToString());

        if (!isDead)
        {

            Debug.Log("not dead");
            enemyHealth = enemyHealth - TheDammage;
            animations.Play("Damage");

            if (enemyHealth <= 0)
            {
                Dead();
            }
        }
    }
    public void Dead()
    {

        Debug.Log("in dead");
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        isDead = true;
        animations.Play("Death");
        Destroy(transform.gameObject, 5);
    }

    public void updatetarget()
    {
        Playerdistance = Vector3.Distance(Player.position, transform.position);
        if (Playerdistance <= attackRange)
        {
            currenttarget = Player;
        }
        else if (targets.Length > 0)
        {
            currenttarget = targets[0];
        }
        else
        {
            currenttarget = Player;
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        Debug.Log("Collision detected");
        Debug.Log(enemyHealth.ToString());
        
        hit.Play ();

        if(other.tag == "Shovel")
        {
            
            Debug.Log("Collision with shovel");
            ApplyDammage(TheDammage);
        }
    }
}
